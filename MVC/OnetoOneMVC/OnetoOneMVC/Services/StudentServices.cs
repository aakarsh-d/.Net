using Microsoft.EntityFrameworkCore;
using OnetoOneMVC.Data;
using OnetoOneMVC.Models;

namespace OnetoOneMVC.Services
{
    public class StudentService
    {
        private readonly StudentManagementContext _context;

        public StudentService(StudentManagementContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                           .Include(s => s.AssignedRoom)
                           .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
