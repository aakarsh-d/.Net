using MassTransit;
using Microsoft.EntityFrameworkCore;
using StudentService.Consumers;
using StudentService.Data;
using StudentService.Services;

var builder = WebApplication.CreateBuilder(args);

// ─── Database ─────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDb")));

// ─── Services ─────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IStudentValidationService, StudentValidationService>();

// ─── MassTransit + RabbitMQ ───────────────────────────────────────────────────
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SeatReservationFailedConsumer>();
    x.AddConsumer<EnrollmentFailedConsumer>();

    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"] ?? "guest");
            h.Password(builder.Configuration["RabbitMQ:Password"] ?? "guest");
        });

        cfg.ReceiveEndpoint("student-seat-reservation-failed", e =>
        {
            e.ConfigureConsumer<SeatReservationFailedConsumer>(ctx);
            e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
        });

        cfg.ReceiveEndpoint("student-enrollment-failed", e =>
        {
            e.ConfigureConsumer<EnrollmentFailedConsumer>(ctx);
            e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
        });
    });
});

// ─── API ──────────────────────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Student Service API", Version = "v1" });
});

var app = builder.Build();

// ─── Auto migrate ─────────────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();