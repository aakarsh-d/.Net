using MVCListRepo.Data;
using MVCListRepo.Models;

namespace MVCListRepo.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SqlStudentRepository(AppDbContext db)
        {
            context = db;
        }

        public List<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}
