using Microsoft.EntityFrameworkCore;

namespace TodoWebApi.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
        {
        }

        public TodoDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            modelBuilder.Entity<TodoGroup>()
                .HasIndex(e => new { e.UserId, e.Name })
                .IsUnique();

            modelBuilder.Entity<Todo>()
                .HasIndex(e => new { e.GroupId, e.Name })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }



        //Tablas de datos
        public virtual DbSet<Todo> Todo { get; set; }
        public virtual DbSet<TodoGroup> TodoGroup { get; set; }
        public virtual DbSet<User> User{ get; set; }
    }
}
