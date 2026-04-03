using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;

namespace StudentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentDbContext _db;

    public StudentsController(StudentDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _db.Students
            .OrderByDescending(s => s.CreatedAt)
            .Select(s => new
            {
                s.Id, s.FullName, s.Email,
                s.NationalId, s.Status,
                s.EnrolledCourseId, s.CreatedAt
            })
            .ToListAsync();

        return Ok(students);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student is null) return NotFound();
        return Ok(student);
    }

    [HttpGet("{id:guid}/validation-logs")]
    public async Task<IActionResult> GetValidationLogs(Guid id)
    {
        var logs = await _db.ValidationLogs
            .Where(v => v.StudentId == id)
            .OrderByDescending(v => v.CreatedAt)
            .ToListAsync();

        return Ok(logs);
    }
}
