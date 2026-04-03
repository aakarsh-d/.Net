using Microsoft.EntityFrameworkCore;
using OneToMany_Dept_.Models;
using OneToManyMVC.Data;

namespace OneToMany_Dept_.Service
{
    public class DepartmentService
    {
        private readonly StudentManagementContext _context;

        public DepartmentService(StudentManagementContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments
                .Include(d => d.Students)
                .ToList();
        }

        public Department GetDepartment(int id)
        {
            return _context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == id);
        }

        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
    }
}