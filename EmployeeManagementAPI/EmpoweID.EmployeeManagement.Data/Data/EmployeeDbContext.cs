using EmpoweID.EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasData(new Department { Id = new Guid("990231a3-4842-481c-88b4-f71857c887ea"), Name = "Admin" },
                new Department { Id = new Guid("0d95f621-1167-4743-9a34-aeb4426a4833"), Name = "Production" },
                new Department { Id = new Guid("1dad7425-84e3-4dd1-b983-d05c5456c0d7"), Name = "IT Support" },
                new Department { Id = new Guid("499943c6-f83c-4348-bd04-9babf6564d96"), Name = "Software Development" }
                );
        }
    }
}