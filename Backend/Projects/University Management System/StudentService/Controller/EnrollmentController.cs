using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Events;
using StudentService.Data;
using StudentService.Models;
using StudentService.Services;

namespace StudentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly StudentDbContext _db;
    private readonly IStudentValidationService _validationService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<EnrollmentController> _logger;

    public EnrollmentController(
        StudentDbContext db,
        IStudentValidationService validationService,
        IPublishEndpoint publishEndpoint,
        ILogger<EnrollmentController> logger)
    {
        _db = db;
        _validationService = validationService;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollmentRequest request)
    {
        var enrollmentId = Guid.NewGuid();

        _logger.LogInformation(
            "Enrollment request received. EnrollmentId={EnrollmentId}", enrollmentId);

        // Step 1: Validate student
        var validationRequest = new StudentValidationRequest(
            request.FullName, request.Email,
            request.NationalId, request.DateOfBirth, request.CourseId);

        var validationResult = await _validationService.ValidateAsync(validationRequest);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed: {Reason}", validationResult.Message);
            return BadRequest(new { error = validationResult.Message });
        }

        // Step 2: Save student to DB
        var student = new Student
        {
            FullName = request.FullName,
            Email = request.Email,
            NationalId = request.NationalId,
            DateOfBirth = request.DateOfBirth,
            Status = EnrollmentStatus.EnrollmentRequested,
            EnrolledCourseId = request.CourseId
        };

        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        _logger.LogInformation(
            "Student {StudentId} saved. Publishing StudentCreated.", student.Id);

        // Step 3: Publish event — triggers Course Service
        await _publishEndpoint.Publish(new StudentCreated(
            EnrollmentId: enrollmentId,
            StudentId: student.Id,
            FullName: student.FullName,
            Email: student.Email,
            CourseId: request.CourseId
        ));

        return Accepted(new
        {
            enrollmentId,
            studentId = student.Id,
            message = "Enrollment started. You will be notified once complete."
        });
    }

    [HttpGet("{studentId:guid}")]
    public async Task<IActionResult> GetStudent(Guid studentId)
    {
        var student = await _db.Students.FindAsync(studentId);
        if (student is null) return NotFound();
        return Ok(student);
    }
}

public record EnrollmentRequest(
    string FullName,
    string Email,
    string NationalId,
    DateTime DateOfBirth,
    Guid CourseId
);