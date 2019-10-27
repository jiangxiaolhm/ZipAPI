using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZipAPI.Models;

namespace ZipAPI.Data
{
    public class ZipDbContext : DbContext
    {
        public ZipDbContext(DbContextOptions<ZipDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => user.EmailAddress)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
