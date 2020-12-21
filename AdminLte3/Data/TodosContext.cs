using AdminLte3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Data
{
    public class TodosContext: DbContext

    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TodoEmployee> TodoEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Team>().ToTable("Department");
            modelBuilder.Entity<TodoEmployee>().ToTable("TodoEmployee");

            modelBuilder.Entity<TodoEmployee>()
                .HasKey(c => new { c.TodoID, c.EmployeeID });
        }

    }
}
