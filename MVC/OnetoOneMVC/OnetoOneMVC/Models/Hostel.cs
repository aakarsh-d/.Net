namespace OnetoOneMVC.Models
{
    public class Hostel
    {
        public int Id { get; set; }
        public string Roomnumber { get; set; }
        public int StudentId { get; set; }
        public Student ResidentStudent { get; set; } 

    }
}
