using CodingCafeV2.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace CodingCafeV2.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Menu> Menu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
               new Customers {
                   ID = 1,
                   FirstName = "Jack",
                   LastName = "Smith",
                   Address = "100 Cafe Circle",
                   City = "Traverse City",
                   State = "MI",
                   Zip = "49684",
                   Email = "jacksmith@gmail.com",
                   Phone = "1234567890",
                   MenuId = 1,
               },
               new Customers {
                   ID = 2,
                   FirstName = "Jill",
                   LastName = "Smith",
                   Address = "100 Cafe Circle",
                   City = "Traverse City",
                   State = "MI",
                   Zip = "49684",
                   Email = "jillsmith@gmail.com",
                   Phone = "1234567891",
                   MenuId = 2, 
               },
               new Customers {
                   ID = 3,
                   FirstName = "Steve",
                   LastName = "Jobs",
                   Address = "123 Apple Way",
                   City = "Detroit",
                   State = "MI",
                   Zip = "56476",
                   Email = "stevejobs@gmail.com",
                   Phone = "1234567892",
                   MenuId = 3,
               },
               new Customers {
                   ID = 4,
                   FirstName = "Bill",
                   LastName = "Gates",
                   Address = "456 Microsoft Ln",
                   City = "Grand Rapids",
                   State = "MI",
                   Zip = "44455",
                   Email = "billgates@gmail.com",
                   Phone = "234567893",
                   MenuId = 4
                  
               }
               );
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    MenuId = 1,
                    Item = "JavaScript Java",
                    Description = "A dark, robust blend."
                },
                new Menu
                {
                    MenuId = 2,
                    Item = ".NET Decaf",
                    Description = "A delicious brew, minus the jitters!"
                },
                new Menu
                {
                    MenuId = 3,
                    Item = "HTML Hot Cocoa",
                    Description = "Traditional hot chocolate, with whip!"
                },
                new Menu
                {
                    MenuId = 4,
                    Item = "LINQ Latte",
                    Description = "A tasty latte made with caramel and vanilla."
                }


                );
                
    }
    }
}
