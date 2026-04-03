using CRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperations.Data
{
    public class CRUDOperationsContext:DbContext
    {
        public CRUDOperationsContext(DbContextOptions<CRUDOperationsContext>options):base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
