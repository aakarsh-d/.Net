using CourseService.Data;
using CourseService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly CourseDbContext _db;
    private readonly ILogger<CoursesController> _logger;

    public CoursesController(CourseDbContext db, ILogger<CoursesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    /// <summary>Returns all active courses with seat availability.</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _db.Courses
            .Where(c => c.IsActive)
            .Select(c => new CourseDto(
                c.Id, c.Name, c.Code, c.Description,
                c.TotalSeats, c.ReservedSeats, c.TotalSeats - c.ReservedSeats,
                c.FeeAmount))
            .ToListAsync();

        return Ok(courses);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course is null) return NotFound();

        return Ok(new CourseDto(
            course.Id, course.Name, course.Code, course.Description,
            course.TotalSeats, course.ReservedSeats,
            course.TotalSeats - course.ReservedSeats,
            course.FeeAmount));
    }

    /// <summary>Returns all enrollments for a course.</summary>
    [HttpGet("{id:guid}/enrollments")]
    public async Task<IActionResult> GetEnrollments(Guid id)
    {
        var enrollments = await _db.Enrollments
            .Where(e => e.CourseId == id)
            .Select(e => new EnrollmentDto(
                e.Id, e.EnrollmentId, e.StudentId,
                e.SeatNumber, e.Status.ToString(), e.ReservedAt))
            .ToListAsync();

        return Ok(enrollments);
    }

    /// <summary>Admin: create a new course.</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
    {
        if (await _db.Courses.AnyAsync(c => c.Code == request.Code))
            return Conflict(new { error = $"Course code '{request.Code}' already exists." });

        var course = new Course
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            TotalSeats = request.TotalSeats,
            FeeAmount = request.FeeAmount
        };

        _db.Courses.Add(course);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
    }
}

public record CourseDto(
    Guid Id, string Name, string Code, string Description,
    int TotalSeats, int ReservedSeats, int AvailableSeats, decimal FeeAmount);

public record EnrollmentDto(
    Guid Id, Guid EnrollmentId, Guid StudentId,
    int SeatNumber, string Status, DateTime ReservedAt);

public record CreateCourseRequest(
    string Name, string Code, string Description,
    int TotalSeats, decimal FeeAmount);
