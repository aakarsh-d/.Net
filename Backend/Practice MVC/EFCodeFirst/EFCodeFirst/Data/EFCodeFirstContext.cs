using Microsoft.EntityFrameworkCore;
using EFCodeFirst.Models;

namespace EFCodeFirst.Data
{
    //main bridge that connect our project with the database
    public class EFCodeFirstContext:DbContext
    {
        public EFCodeFirstContext(DbContextOptions<EFCodeFirstContext>options):base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
