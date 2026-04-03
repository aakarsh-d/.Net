namespace OneToMany_Dept_.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        // One Department → Many Students
        public List<Student> Students { get; set; }
    }
}
