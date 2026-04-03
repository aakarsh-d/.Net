using Hostelmanagement.DTO;
using Hostelmanagement.Models;

namespace Hostelmanagement.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student, Hostel hostel);

        void UpdateRoom(int hostelId, int roomNo);

        void DeleteStudent(int id);

        List<Student> GetHostelStudents();

        List<Student> GetAllStudents();
        void CreateStudent(CreateStudentDto dto);

        void UpdateRoom(UpdateRoomDto dto);
    }
}
