using Microsoft.EntityFrameworkCore;
using Minimal_API.Models;
using Task = Minimal_API.Models.Task;

namespace Minimal_API
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categoria");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired().HasMaxLength(100); ;
                category.Property(p => p.Description);
            });

            modelBuilder.Entity<Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                task.Property(p => p.Title).HasMaxLength(100);
                task.Property(p => p.Description);
                task.Property(p => p.TaskPriority);
                task.Property(p => p.DateTimeCreated);
                task.Ignore(p => p.Resumen);
            });

        }
    }
}
