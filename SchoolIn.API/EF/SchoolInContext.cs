using System;
using Microsoft.EntityFrameworkCore;

namespace SchoolIn.API.EF
{
    public class SchoolInContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public SchoolInContext(DbContextOptions<SchoolInContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./SchoolIn.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.UserID);
            modelBuilder.Entity<Post>().HasKey(x => x.PostID);
            modelBuilder.Entity<User>().HasMany(x => x.Permissions);
            base.OnModelCreating(modelBuilder);
        }
    }
}
