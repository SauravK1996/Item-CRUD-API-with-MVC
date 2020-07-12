using ItemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasData(
                                new User 
                                {
                                    UserId = 1,
                                    Username = "test",
                                    Password = "test",
                                    Role = "test"
                                }, 
                                new User
                                {
                                    UserId = 2,
                                    Username = "Admin",
                                    Password = "Admin",
                                    Role = "Admin"
                                }
                         );

            modelBuilder.Entity<Item>()
                        .HasData(
                                new Item
                                {
                                    ItemId = 1,
                                    Title = "Web Server",
                                    Description = "IIS 7.0",
                                    UnitType = "Hours",
                                    Rate = "20"
                                }, 
                                new Item
                                {
                                    ItemId = 2,
                                    Title = "Logo Design",
                                    Description = "Designed a logo for app",
                                    UnitType = "PC",
                                    Rate = "100"
                                }, 
                                new Item
                                {
                                    ItemId = 3,
                                    Title = "Application Development",
                                    Description = "Php application for project management",
                                    UnitType = "Hours",
                                    Rate = "20"
                                }
                        );
        }
    }
}
