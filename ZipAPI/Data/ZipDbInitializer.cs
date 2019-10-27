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
            context.Database.EnsureCreated();

            if (!context.Users.Any() && !context.Accounts.Any())
            {
                Console.WriteLine("Seeding Database...");
                context.AddRange(new User
                {
                    Name = "User A",
                    EmailAddress = "usera@email.com",
                    MonthlySalary = 2000,
                    MonthlyExpenses = 1000,
                    Account = new Account()
                }, new User
                {
                    Name = "User B",
                    EmailAddress = "userb@email.com",
                    MonthlySalary = 2000,
                    MonthlyExpenses = 1500,
                }, new User
                {
                    Name = "User C",
                    EmailAddress = "userc@email.com",
                    MonthlySalary = 2000,
                    MonthlyExpenses = 500,
                });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding.");
            }
        }
    }
}
