﻿using Microsoft.EntityFrameworkCore;

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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("Server=localhost;Database=todo_app;Uid=todo_app;Pwd=1234;", ServerVersion.FromString("10.5.8-mariadb"));
        //    }
        //}

        //Tablas de datos
        public virtual DbSet<Todo> Todo { get; set; }
        public virtual DbSet<TodoGroup> TodoGroup { get; set; }
        public virtual DbSet<User> User{ get; set; }
    }
}
