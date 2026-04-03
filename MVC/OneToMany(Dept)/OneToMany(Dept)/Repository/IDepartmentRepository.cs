
using OneToMany_Dept_.Models;

namespace OneToMany_Dept_.Repository
{
    //public interface IDepartmentRepository
    //{
    //    List<Department>GetAllDepartments();
    //    void AddDepartment(Department department);
    //}



    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();

        Department GetDepartment(int id);

        Department AddDepartment(Department department);

        Student AddStudent(Student student);
    }
}
