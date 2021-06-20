using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Initialization
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BeSpokedContext>
    {
        /// <summary>
        /// Builds and adds seed data for needed databases.
        /// </summary>
        /// <param name="context">The DbContext to connect with sql</param>
        protected override void Seed(BeSpokedContext context)
        {
            var products = new List<Product>
            {
                new Product {ProductId = Guid.NewGuid(), Name = "SupahFastBike", Manufacturer = "TheBestBikeMaker", Style = "Very good bike", PurchasePrice = 199.99M, SalePrice = 199.99M, QtyOnHand = 32, CommissionPercentage = 12.5M},
                new Product {ProductId = Guid.NewGuid(), Name = "LowRiderBike", Manufacturer = "TheCoolestBikeMaker", Style = "Very cool bike", PurchasePrice = 200, SalePrice = 150, QtyOnHand = 16, CommissionPercentage = 10},
                new Product {ProductId = Guid.NewGuid(), Name = "HotRodBike", Manufacturer = "TheCoolestBikeMaker", Style = "Very hot bike", PurchasePrice = 350, SalePrice = 350, QtyOnHand = 93, CommissionPercentage = 15},
                new Product {ProductId = Guid.NewGuid(), Name = "MegaUltraMountainBike", Manufacturer = "HardCoreBikeMaker", Style = "Very rugged bike", PurchasePrice = 150, SalePrice = 150, QtyOnHand = 6, CommissionPercentage = 5},
                new Product {ProductId = Guid.NewGuid(), Name = "LittleKiddyBabyBike", Manufacturer = "GrandmaTheBikeMaker", Style = "Very comfortable and safe bike", PurchasePrice = 49.99M, SalePrice = 99.99M, QtyOnHand = 2}
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            //Helper variable to simplify adding dates
            var today = DateTime.Today;
            var salespersons = new List<Salesperson>
            {
                new Salesperson {SalespersonId = Guid.NewGuid(), Firstname = "Jessica", LastName = "SellsALot", Address = "1002 VeryGood Salesperson Dr.", Phone = "1234567890", StartDate = today.AddDays(-900), Manager = "Martha VeryGoodManager"},
                new Salesperson {SalespersonId = Guid.NewGuid(), Firstname = "Marisha", LastName = "NotSoGreat", Address = "3153 NotSoGoodOfA Salesperson Ln.", Phone = "2345678901", StartDate = today.AddDays(-33), TerminationDate = today.AddDays(5), Manager = "Jeff NotTheBestManager"},
                new Salesperson {SalespersonId = Guid.NewGuid(), Firstname = "Robert", LastName = "WatchesYoutubeAllDay", Address = "1653 NotSoGoodOfA Salesperson Ln.", Phone = "3456789012", StartDate = today.AddDays(-130), TerminationDate = today.AddDays(-56), Manager = "Jeff NotTheBestManager"},
                new Salesperson {SalespersonId = Guid.NewGuid(), Firstname = "Amir", LastName = "BestSalesman", Address = "643 VeryGood Salesperson Dr.", Phone = "4567890123", StartDate = today.AddDays(-1500), Manager = "Martha VeryGoodManager"},
                new Salesperson {SalespersonId = Guid.NewGuid(), Firstname = "Susan", LastName = "NeedsAPromotion", Address = "782 VeryGood Salesperson Dr.", Phone = "5678901234", StartDate = today.AddDays(-2349), Manager = "Martha VeryGoodManager"},
            };
            salespersons.ForEach(s => context.Salespersons.Add(s));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer {CustomerId = Guid.NewGuid(), FirstName = "Billy", LastName = "BuysSomeBikes", Address = "3698 Biking Trail Way", Phone = "6789012345", StartDate = today.AddDays(-400)},
                new Customer {CustomerId = Guid.NewGuid(), FirstName = "Laura", LastName = "BicycleGang", Address = "468 Hardcore Trl.", Phone = "7890123456", StartDate = today.AddDays(-56)},
                new Customer {CustomerId = Guid.NewGuid(), FirstName = "Lexie", LastName = "TrainingWheels", Address = "418 Teapot St. ", Phone = "8901234567", StartDate = today},
                new Customer {CustomerId = Guid.NewGuid(), FirstName = "Merle", LastName = "Highchurch", Address = "265 Bureau of Balance Cir.", Phone = "9012345678", StartDate = today.AddDays(-420)},
                new Customer {CustomerId = Guid.NewGuid(), FirstName = "Taako", LastName = "FromTV", Address = "653 Fantasy Costco Blvd.", Phone = "0123456789", StartDate = today.AddDays(-69)}
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var discounts = new List<Discount>
            {
                new Discount {ProductId = products[1].ProductId, BeginDate = today, EndDate = today.AddDays(7), DiscountPercentage = 25},
                new Discount {ProductId = products[3].ProductId, BeginDate = today.AddDays(-50), EndDate = today.AddDays(-43), DiscountPercentage = 16.66M},
                new Discount {ProductId = products[4].ProductId, BeginDate = today.AddDays(-7), EndDate = today, DiscountPercentage = 50},
                new Discount {ProductId = products[0].ProductId, BeginDate = today.AddDays(7), EndDate = today.AddDays(14), DiscountPercentage = 10},
                new Discount {ProductId = products[2].ProductId, BeginDate = today.AddDays(14), EndDate = today.AddDays(21), DiscountPercentage = 5},
            };
            discounts.ForEach(d => context.Discounts.Add(d));
            context.SaveChanges();

            var sales = new List<Sale>
            {
                new Sale {SalesId = Guid.NewGuid(), ProductId = products[0].ProductId, SalespersonId = salespersons[3].SalespersonId, CustomerId = customers[4].CustomerId, SalesDate = today.AddDays(-15)},
                new Sale {SalesId = Guid.NewGuid(), ProductId = products[1].ProductId, SalespersonId = salespersons[0].SalespersonId, CustomerId = customers[0].CustomerId, SalesDate = today.AddDays(-36)},
                new Sale {SalesId = Guid.NewGuid(), ProductId = products[2].ProductId, SalespersonId = salespersons[4].SalespersonId, CustomerId = customers[1].CustomerId, SalesDate = today.AddDays(-6)},
                new Sale {SalesId = Guid.NewGuid(), ProductId = products[3].ProductId, SalespersonId = salespersons[3].SalespersonId, CustomerId = customers[3].CustomerId, SalesDate = today.AddDays(-96)},
                new Sale {SalesId = Guid.NewGuid(), ProductId = products[4].ProductId, SalespersonId = salespersons[1].SalespersonId, CustomerId = customers[2].CustomerId, SalesDate = today.AddDays(-57)}
            };
            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();
        }
    }
}
