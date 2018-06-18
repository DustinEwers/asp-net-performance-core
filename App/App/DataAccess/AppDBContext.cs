using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(DataGenerators.GenerateCustomers().ToArray());
            modelBuilder.Entity<Product>().HasData(DataGenerators.GenerateProducts().ToArray());
        }
    }
}
