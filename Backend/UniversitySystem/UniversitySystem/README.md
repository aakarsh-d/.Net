# University Enrollment System
### Saga Pattern + 3 Microservices + RabbitMQ + EF Core Code First

---

## Architecture

```
Client
  │
  └──► POST /api/enrollment   (Student Service :5001)
         │  Validate student
         │  Save to StudentDb
         │  Publish ──► StudentCreated
                               │
                    ┌──────────▼──────────┐
                    │   Course Service     │  :5002
                    │   Receives event     │
                    │   Checks seats       │
                    │   Reserves seat      │
                    │   Publish ──► SeatReserved
                    └─────────────────────┘
                                          │
                               ┌──────────▼──────────┐
                               │    Fee Service        │  :5003
                               │    Receives event     │
                               │    Creates fee record │
                               │    Publish ──► FeeCreated ✓
                               └───────────────────────┘

On any failure → EnrollmentFailed published → compensation runs backwards
```

---

## Project Structure

```
UniversitySystem/
├── docker-compose.yml
└── src/
    ├── Shared.Contracts/           ← shared event classes (all services reference this)
    │   └── Events/EnrollmentEvents.cs
    ├── StudentService/             ← saga entry point, port 5001
    │   ├── Controllers/
    │   │   ├── EnrollmentController.cs
    │   │   └── StudentsController.cs
    │   ├── Consumers/
    │   │   └── EnrollmentCompensationConsumers.cs
    │   ├── Data/StudentDbContext.cs
    │   ├── Models/Student.cs
    │   ├── Services/StudentValidationService.cs
    │   ├── Program.cs
    │   ├── appsettings.json
    │   └── Dockerfile
    ├── CourseService/              ← saga step 2, port 5002
    │   ├── Controllers/CoursesController.cs
    │   ├── Consumers/CourseConsumers.cs
    │   ├── Data/CourseDbContext.cs
    │   ├── Models/Course.cs
    │   ├── Program.cs
    │   ├── appsettings.json
    │   └── Dockerfile
    └── FeeService/                 ← saga step 3 (final), port 5003
        ├── Controllers/FeesController.cs
        ├── Consumers/SeatReservedConsumer.cs
        ├── Data/FeeDbContext.cs
        ├── Models/FeeRecord.cs
        ├── Program.cs
        ├── appsettings.json
        └── Dockerfile
```

---

## Quick Start — Run Everything with Docker

```bash
# From the UniversitySystem/ root folder
docker compose up --build
```

Wait ~30 seconds for all containers to be healthy. Then open:

| Service            | URL                              |
|--------------------|----------------------------------|
| Student Service    | http://localhost:5001/swagger    |
| Course Service     | http://localhost:5002/swagger    |
| Fee Service        | http://localhost:5003/swagger    |
| RabbitMQ UI        | http://localhost:15672           |

RabbitMQ login: `guest` / `guest`

---

## Run Locally Without Docker (Development)

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB is fine)
- RabbitMQ running locally (or use Docker just for RabbitMQ)

### Step 1 — Run RabbitMQ only via Docker
```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

### Step 2 — Update connection strings in each appsettings.json

For LocalDB, change `StudentDb` connection string to:
```
Server=(localdb)\\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;
```
Do the same for CourseDb and FeeDb.

### Step 3 — Apply EF Core migrations

Run these commands from the `src/` folder:

```bash
# Student Service migrations
cd StudentService
dotnet ef migrations add InitialCreate --project StudentService.csproj
dotnet ef database update
cd ..

# Course Service migrations (includes seed data for 3 courses)
cd CourseService
dotnet ef migrations add InitialCreate --project CourseService.csproj
dotnet ef database update
cd ..

# Fee Service migrations
cd FeeService
dotnet ef migrations add InitialCreate --project FeeService.csproj
dotnet ef database update
cd ..
```

> Note: When running with Docker, migrations are applied automatically on startup via `db.Database.Migrate()` in Program.cs.

### Step 4 — Run all 3 services

Open 3 terminals:

```bash
# Terminal 1
cd src/StudentService && dotnet run

# Terminal 2
cd src/CourseService && dotnet run

# Terminal 3
cd src/FeeService && dotnet run
```

---

## Test the Full Saga

### 1. Get available courses (Course Service)
```
GET http://localhost:5002/api/courses
```

Copy one of the course IDs (seeded: CS101, BA101, EE101).

### 2. Enroll a student (Student Service) — starts the saga
```
POST http://localhost:5001/api/enrollment
Content-Type: application/json

{
  "fullName": "Arjun Singh",
  "email": "arjun.singh@example.com",
  "nationalId": "PB-2024-001",
  "dateOfBirth": "2000-03-15T00:00:00Z",
  "courseId": "11111111-1111-1111-1111-111111111111"
}
```

Response (202 Accepted):
```json
{
  "enrollmentId": "...",
  "studentId": "...",
  "message": "Enrollment started. You will be notified once complete."
}
```

### 3. Check fee was created (Fee Service)
```
GET http://localhost:5003/api/fees/enrollment/{enrollmentId}
```

### 4. Check seat was reserved (Course Service)
```
GET http://localhost:5002/api/courses/11111111-1111-1111-1111-111111111111/enrollments
```

### 5. Check student status (Student Service)
```
GET http://localhost:5001/api/students/{studentId}
```

### 6. Test compensation — enroll with same email (should fail)
```
POST http://localhost:5001/api/enrollment
{
  "fullName": "Arjun Singh",
  "email": "arjun.singh@example.com",   ← same email
  "nationalId": "PB-2024-002",
  "dateOfBirth": "2000-03-15T00:00:00Z",
  "courseId": "11111111-1111-1111-1111-111111111111"
}
```
Returns 400 immediately — validation stops the saga before it starts.

---

## Saga Event Flow

### Happy Path
```
POST /api/enrollment
  → StudentService: validates → saves Student → publishes StudentCreated
  → CourseService:  reserves seat → publishes SeatReserved
  → FeeService:     creates fee record → publishes FeeCreated ✓ DONE
```

### Failure Path (e.g. no seats)
```
POST /api/enrollment
  → StudentService: validates → saves Student → publishes StudentCreated
  → CourseService:  no seats → publishes SeatReservationFailed
  → StudentService: receives SeatReservationFailed → marks student as Failed
                    → publishes StudentEnrollmentCancelled ✓ COMPENSATED
```

### Failure Path (fee service error)
```
POST /api/enrollment
  → StudentService: validates → saves Student → publishes StudentCreated
  → CourseService:  reserves seat → publishes SeatReserved
  → FeeService:     error → publishes EnrollmentFailed
  → CourseService:  receives EnrollmentFailed → releases seat → publishes SeatReleased
  → StudentService: receives EnrollmentFailed → marks student as Failed ✓ COMPENSATED
```

---

## RabbitMQ Queues Created Automatically

| Queue Name                        | Consumer                        |
|-----------------------------------|---------------------------------|
| student-seat-reservation-failed   | SeatReservationFailedConsumer   |
| student-enrollment-failed         | EnrollmentFailedConsumer        |
| course-student-created            | StudentCreatedConsumer          |
| course-enrollment-failed          | EnrollmentFailedConsumer        |
| fee-seat-reserved                 | SeatReservedConsumer            |

MassTransit creates these queues automatically when the services start.
You can see them live at http://localhost:15672 → Queues tab.

---

## Key Design Decisions

| Decision | Why |
|----------|-----|
| Choreography (not orchestration) | Simpler — no central saga controller needed |
| Idempotency check in FeeService | Prevents duplicate fee records if message is delivered twice |
| `db.Database.Migrate()` on startup | Auto-creates DB schema in Docker without manual steps |
| Separate `EnrollmentId` (Guid) | Correlation ID to track the same saga across all 3 services |
| Retry policy (3x, 5s interval) | Handles transient failures (DB blip, network hiccup) |
| Seed data in CourseDbContext | CS101, BA101, EE101 ready to use immediately after migrate |
