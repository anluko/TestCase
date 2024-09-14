using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Windows
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<HeadDepartments> HeadDepartments { get; set; }
        public DbSet<Positions> Positions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EmployeeRecords;Username=postgres;Password=Vaffchelov_B223");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey(d => d.EmployeeId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<HeadDepartments>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<HeadDepartments>()
                .HasOne(d => d.HeadDepartment)
                .WithMany()
                .HasForeignKey(d => d.HeadDepartmentId);

            modelBuilder.Entity<HeadDepartments>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId);
        }
    }
}
