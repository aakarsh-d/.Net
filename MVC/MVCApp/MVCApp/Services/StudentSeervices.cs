using MVCApp.Repositories;
using MVCApp.Models;    
namespace MVCApp.Services
{
    public class StudentSeervices :IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentSeervices(IStudentRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Student>> SearchAsync(string q = null) => _repo.GetAllAsync(q);

    }
}
