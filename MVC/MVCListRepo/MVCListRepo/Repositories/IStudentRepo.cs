using MVCListRepo.Models;

namespace MVCListRepo.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}
