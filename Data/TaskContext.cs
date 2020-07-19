using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using WebApi.Models;

namespace WebApi.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
        { }
        public DbSet<User> User { get; set; }
        //public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                //entity.HasMany(e => e.User)
                //    .WithOne(x => x.Category)
                //    .HasForeignKey(f => f.CategoryId);
                //entity.HasData(new Category[] { new Category() { Name = "DEV" }, new Category() { Name = "QA" }, new Category() { Name = "PM" }, });

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryId");

                entity.Property(e => e.CreationTime)
                    .HasColumnName("CreationTime")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("getutcdate()");
                entity.HasOne(u => u.Category).WithMany(c => c.User).HasForeignKey(f => f.CategoryId);
                //entity.HasData(new User[] { new User() { CategoryId = 1 }, new User() { CategoryId = 2 }, new User() { CategoryId = 3 }, new User() { CategoryId = 3 }, new User() { CategoryId = 2 }, new User() { CategoryId = 1 }, });
            });
        }
        //modelBuilder.Entity<User>().Ignore(c => c.CategoryForeignKey);
        //modelBuilder.Entity<Category>().HasMany(c=>c.)
        //modelBuilder.Entity<User>().HasKey(x => x.Category.Id);
        //.HasOne(c => c.Category).WithMany().HasForeignKey(i=>i.CategoryForeignKey);


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=Applebrie.db");
    }

    //public class TaskContextFactory : IDesignTimeDbContextFactory<TaskContext>
    //{
    //    public TaskContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<TaskContext>();
    //        optionsBuilder.UseSqlite("Data Source=Applebrie.db");

    //        return new TaskContext(optionsBuilder.Options);
    //    }
    //}
}
