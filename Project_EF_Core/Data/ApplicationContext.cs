using Microsoft.EntityFrameworkCore;
using Project_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(e => e.Settings).WithOne(e => e.User);
            modelBuilder.Entity<User>().HasMany(e => e.Transactions).WithOne(e => e.User);
            modelBuilder.Entity<Category>().HasMany(e => e.Transactions).WithOne(e => e.Category);
            base.OnModelCreating(modelBuilder);
        }
    }
}
