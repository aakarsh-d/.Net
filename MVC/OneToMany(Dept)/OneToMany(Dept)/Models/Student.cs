namespace OneToMany_Dept_.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }   // Foreign Key

        public Department Department { get; set; }
    }
}
