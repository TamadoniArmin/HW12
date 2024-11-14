using HW12.DB;
using HW12.Task;
using Microsoft.EntityFrameworkCore;

namespace HW12.Tools
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6RE5DJR\SQLEXPRESS;Initial Catalog=DutyManager;User Id=sa; password=arminpooma00;Integrated Security=SSPI;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
