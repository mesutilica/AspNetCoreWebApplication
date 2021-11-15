using Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB; Database=AspNetCoreWebApplication; Trusted_Connection=True; MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                   HasData(new User
                   {
                       Id = 1,
                       Username = "Admin",
                       Password = "123456",
                       Email = "admin@NetCoreWebApplication.net",
                       Name = "demo",
                       Surname = "test",
                       Phone = "0216",
                       CreateDate = DateTime.Now,
                       IsActive = true,
                       IsAdmin = true
                   });
            base.OnModelCreating(modelBuilder);
        }
    }
}
//add-migration galleriesAdded -context DataBaseContext
//update-database -context DataBaseContext