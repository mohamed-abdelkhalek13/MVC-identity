using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using MVC2.ViewModels;
namespace MVC2.Models
{
    public class CompanyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Dependent> dependents { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<WorksOn> workson { get; set; }
        public CompanyContext() { }
        public CompanyContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-P3QHCGH\\SQLEXPRESS;Initial Catalog=identityDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dependent>().HasKey("name", "employeeid");
            modelBuilder.Entity<WorksOn>().HasKey("employeeid", "projectid");
            modelBuilder.Entity<Department>().HasOne(e => e.employee).WithOne(d => d.departmentMNG);
            modelBuilder.Entity<Department>().HasMany(e => e.employees).WithOne(d => d.departmentWF);


        }

        public DbSet<MVC2.ViewModels.identityuserVM> identityuserVM { get; set; } = default!;
    }
}
