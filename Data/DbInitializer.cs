using BeSpokedBikes.Models;
using System;
using System.Linq;

namespace BeSpokedBikes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BeSpokedContext context)
        {
            //If there are any products, just return.DB is already seeded.
            if (context.Products.Any())
            {
                return;
            }

            // Seed Products, Salesperson, Customers first
            var products = new Product[]
            {
                new Product { Name = "Mountain Bike", Manufacturer = "Firefly Bicycles", Style = "Mountain", PurchasePrice = 500, SalePrice = 1000, QtyOnHand = 10, CommissionPercentage = 0.05m },
                new Product { Name = "Road Bike", Manufacturer = "Giant", Style = "Road", PurchasePrice = 700, SalePrice = 1400, QtyOnHand = 8, CommissionPercentage = 0.06m },
                new Product { Name = "Hybrid Bike", Manufacturer = "Seven Cycles", Style = "Hybrid", PurchasePrice = 300, SalePrice = 600, QtyOnHand = 15, CommissionPercentage = 0.04m }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var salespersons = new Salesperson[]
            {
                new Salesperson { FirstName = "Omar", LastName = "Ali", Address = "123 Main St", Phone = "555-1234", StartDate = DateTime.Parse("2022-01-01"), Manager = false },
                new Salesperson { FirstName = "Rohan", LastName = "Thakur", Address = "456 Elm St", Phone = "555-5678", StartDate = DateTime.Parse("2021-06-15"), Manager = false },
                new Salesperson { FirstName = "Aisha", LastName = "Washington", Address = "789 Main St", Phone = "555-9101", StartDate = DateTime.Parse("2022-01-01"), Manager = false },
                new Salesperson { FirstName = "Janet", LastName = "Smith", Address = "101 Elm St", Phone = "555-2131", StartDate = DateTime.Parse("2021-07-15"), Manager = false },
                new Salesperson { FirstName = "Carlos", LastName = "Santiago", Address = "213 Elm St", Phone = "555-4151", StartDate = DateTime.Parse("2021-06-15"), Manager = true }
            };
           context.Salespersons.AddRange(salespersons);
           context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer { FirstName = "Gladys", LastName = "Knight", Address = "789 Oak St", Phone = "555-9012", StartDate = DateTime.Parse("2023-03-10") },
                new Customer { FirstName = "James", LastName = "Brown", Address = "321 Pine St", Phone = "555-3456", StartDate = DateTime.Parse("2023-04-20") },
                new Customer { FirstName = "Magic", LastName = "Johnson", Address = "777 Oak St", Phone = "555-5522", StartDate = DateTime.Parse("2023-03-10") },
                new Customer { FirstName = "Michael", LastName = "Jordan", Address = "222 Pine St", Phone = "555-6547", StartDate = DateTime.Parse("2023-04-20") }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            // Seed Sales and Discount after IDs are created for above entities
            var sales = new Sale[]
            {
                new Sale { ProductId = products[0].Id, SalespersonId = salespersons[0].Id, CustomerId = customers[0].Id, SalesDate = DateTime.Parse("2023-01-15") },
                new Sale { ProductId = products[1].Id, SalespersonId = salespersons[1].Id, CustomerId = customers[1].Id, SalesDate = DateTime.Parse("2023-02-20") }
            };
            context.Sales.AddRange(sales);
            context.SaveChanges();

            var discounts = new Discount[]
            {
                new Discount { ProductId = products[0].Id, BeginDate = DateTime.Parse("2023-06-01"), EndDate = DateTime.Parse("2023-06-30"), DiscountPercentage = 0.10m }
            };
            context.Discounts.AddRange(discounts);
            context.SaveChanges();
        }
    }
}