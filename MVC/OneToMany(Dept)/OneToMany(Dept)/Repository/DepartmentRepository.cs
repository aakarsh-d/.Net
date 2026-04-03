using Microsoft.EntityFrameworkCore;
using OneToMany_Dept_.Data;
using OneToMany_Dept_.Models;

namespace OneToMany_Dept_.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentManagementContext _context;

        public DepartmentRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments
                    .Include(d => d.Students)
                    .ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
    }
}