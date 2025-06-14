using Microsoft.EntityFrameworkCore;

namespace lab2.Models
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context>options):base(options)
        {
            
        }
        public DbSet<Course>courses { get; set; }
        public DbSet<Crsresult> crsresult { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> traines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER01;Initial Catalog=mvc;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instructor>()
                .Property(i => i.Salary)
                .HasPrecision(10, 2); 
        }

    }
}
