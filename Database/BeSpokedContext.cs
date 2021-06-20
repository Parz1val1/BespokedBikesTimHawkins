using System.Data.Entity;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database
{
    public class BeSpokedContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Salesperson> Salespersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
