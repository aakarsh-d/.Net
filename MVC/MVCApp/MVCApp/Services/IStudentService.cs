using MVCApp.Models;

namespace MVCApp.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchAsync(string q = null);
    }
}
