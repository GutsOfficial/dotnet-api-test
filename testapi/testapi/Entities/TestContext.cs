using Microsoft.EntityFrameworkCore;

namespace testapi.Entities
{
    public class TestContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=TestDb;Integrated Security=True;");
        }
    }
}
