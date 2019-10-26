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

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
