using Microsoft.EntityFrameworkCore;

namespace Task4Api.Model
{
    public class Task4DbContext:DbContext
    {
        public Task4DbContext()
        {
            
        }
        public Task4DbContext(DbContextOptions<Task4DbContext>options):base(options) {
        }
       public DbSet<Catalog> Catalog { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
