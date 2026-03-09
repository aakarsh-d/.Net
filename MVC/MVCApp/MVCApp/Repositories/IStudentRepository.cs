using MVCApp.Models;

namespace MVCApp.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string q = null);
    }
}
