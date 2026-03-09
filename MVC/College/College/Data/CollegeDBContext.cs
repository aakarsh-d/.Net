using Microsoft.EntityFrameworkCore;
using College.Models;
//using College.Models;
namespace College.Data
{
    

    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
