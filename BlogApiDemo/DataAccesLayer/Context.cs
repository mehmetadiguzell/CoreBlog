using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccesLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CoreBlogApiDb;Trusted_Connection=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
