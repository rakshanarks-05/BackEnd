using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UsersLogin { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.userId);

            modelBuilder.Entity<User>()
                .HasMany(a => a.Tasks)
                .WithOne(p => p.Assignee)
                .HasForeignKey(a => a.AssigneeId);

            modelBuilder.Entity<TaskItem>()
                .HasMany(a=>a.Checklists)
                .WithOne(c=>c.Task)
                .HasForeignKey(c=>c.TaskId);
                
              
                
                
             

            base.OnModelCreating(modelBuilder);
        }
    }
       
        
        

        
    
}
