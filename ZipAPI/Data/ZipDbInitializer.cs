using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZipAPI.Models;

namespace ZipAPI.Data
{
    public class ZipDbInitializer
    {
        public static void InitilizeDb(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<ZipDbContext>());
        }

        public static void SeedData(ZipDbContext context)
        {
            Console.WriteLine("Appling Migrations...");
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Console.WriteLine("Seeding Database...");
            var user = new User { Name = "Eric Lin", EmailAddress = "jiangxiao.lhm@gmail.com", MonthlySalary = 2000, MonthlyExpenses = 1000 };
            var account = new Account { User = user };
            context.Add<User>(user);
            context.Add<Account>(account);
            context.SaveChanges();
        }
    }
}
