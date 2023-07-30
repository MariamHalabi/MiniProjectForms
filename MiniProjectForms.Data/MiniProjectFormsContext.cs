using Microsoft.EntityFrameworkCore;
using MiniProjectForms.Models;
using MiniProjectForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MiniProjectForms.Data
{
    public class MiniProjectFormsContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public MiniProjectFormsContext(DbContextOptions<MiniProjectFormsContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MiniProjectForms;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().HasKey(t => t.Id);

            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel() { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, IsCompleted = false , DeviceId = "OPPO A74" },
                new TaskModel() { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, IsCompleted = true, DeviceId = "OPPO A74" });
                }

    }
}