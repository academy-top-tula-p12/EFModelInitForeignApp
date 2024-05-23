using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelInitForeignApp
{
    public class EmployeeAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public EmployeeAppContext()
        {    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISC66B9\\MSSQLSERVER2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database=hr_db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>().HasData(companies);
            //modelBuilder.Entity<Employee>().HasData(employees);

            //modelBuilder.Entity<Passport>()
            //            .HasKey(p => p.Number);
            

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Passport)
            //            .WithOne(p => p.Employee)
            //            .HasForeignKey<Passport>(p => p.EmployeeId);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Company)
            //            .WithMany(c => c.Employees)
            //            .HasForeignKey(e => e.CompanyId)
            //            .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Company)
            //            .WithMany(c => c.Employees)
            //            .HasForeignKey(e => e.CompanyTitle)
            //            .HasPrincipalKey(c => c.Title);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Company)
                        .WithMany(c => c.Employees)
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public void DeleteCreate()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public void HasData()
        {
            

            
        }
    }
}
