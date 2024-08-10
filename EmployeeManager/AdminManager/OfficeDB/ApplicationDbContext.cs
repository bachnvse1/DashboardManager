using Microsoft.EntityFrameworkCore;
using ProjectFS2.Entity;

namespace AdminManager.OfficeDB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseNpgsql(config.GetConnectionString("PostgreSQLConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Employee-Department relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.user);

            // User-Employee relationship (one-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.employee)
                .WithOne(e => e.user)
                .HasForeignKey<Employee>(e => e.UserId);

            modelBuilder.Entity<User>()
               .HasOne(u => u.department)
               .WithMany(r => r.user)
               .HasForeignKey(e => e.DepartmentId);
        }
    }
}
