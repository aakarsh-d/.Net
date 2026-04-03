//using CollegeAPI.Models;
using Hostelmanagement.DTO;
using Hostelmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostelmanagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;

        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        // CREATE STUDENT + HOSTEL
        public void CreateStudent(Student student, Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();

            student.HostelId = hostel.HostelId;

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // UPDATE ROOM NUMBER
        public void UpdateRoom(int hostelId, int roomNo)
        {
            var hostel = _context.Hostels.Find(hostelId);

            if (hostel != null)
            {
                hostel.RoomNo = roomNo;
                _context.SaveChanges();
            }
        }

        // DELETE STUDENT
        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        // READ STUDENTS IN HOSTEL
        public List<Student> GetHostelStudents()
        {
            return _context.Students
                .Include(s => s.Hostel)
                .Where(s => s.HostelId != null)
                .ToList();
        }

        // READ ALL COLLEGE STUDENTS
        public List<Student> GetAllStudents()
        {
            return _context.Students
                .Include(s => s.Hostel)
                .ToList();
        }


        public void CreateStudent(CreateStudentDto dto)
        {
            Hostel hostel = new Hostel
            {
                HostelName = dto.HostelName,
                RoomNo = dto.RoomNo
            };

            _context.Hostels.Add(hostel);
            _context.SaveChanges();

            Student student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                HostelId = hostel.HostelId
            };

            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void UpdateRoom(UpdateRoomDto dto)
        {
            var hostel = _context.Hostels.Find(dto.HostelId);

            if (hostel != null)
            {
                hostel.RoomNo = dto.RoomNo;
                _context.SaveChanges();
            }
        }
    }
}