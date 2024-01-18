using Abp.EntityFrameworkCore;
using Acme.SimpleTaskSystem.People;
using Acme.SimpleTaskSystem.Tasks;
using Acme.SimpleTaskSystem.Users;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acme.SimpleTaskSystem.EntityFrameworkCore
{
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public SimpleTaskSystemDbContext(DbContextOptions<SimpleTaskSystemDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>().ToTable("StsTasks");
            modelBuilder.Entity<Person>().ToTable("AppPersons");
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
