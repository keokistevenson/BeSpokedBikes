using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Data
{
    public class BeSpokedContext : DbContext
    {
        public BeSpokedContext(DbContextOptions<BeSpokedContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Salesperson> Salespersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}