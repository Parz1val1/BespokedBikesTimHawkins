using System;
using System.Collections.Generic;
using System.Linq;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;

namespace BespokedBikesTimHawkins.Handlers
{
    public class CommissionReportHandler : ICommissionReportHandler
    {
        private readonly SalespersonRepository salespersonRepo;
        private readonly SaleRepository saleRepo;
        private readonly ProductRepository productRepo;
        private const string Q1 = "01/01/";
        private const string Q2 = "04/01/";
        private const string Q3 = "07/01/";
        private const string Q4 = "10/01/";

        public CommissionReportHandler(SalespersonRepository salespersonRepo, SaleRepository saleRepo, ProductRepository productRepo)
        {
            this.salespersonRepo = salespersonRepo;
            this.saleRepo = saleRepo;
            this.productRepo = productRepo;
        }

        public IList<CommissionReportEntity> GenerateReports(string quarter, int year)
        {
            var commissionReportEntities = new List<CommissionReportEntity>();
            var salespersons = this.salespersonRepo.GetAll();
            foreach(Salesperson s in salespersons)
            {
                //Determines the start and end dates for the quarter...yes it's 12:55AM why do you ask?
                DateTime startDate, endDate;
                switch (quarter)
                {
                    case ("Q1"):
                        startDate = DateTime.Parse(Q1 + year);
                        endDate = DateTime.Parse(Q2 + year);
                        break;
                    case ("Q2"):
                        startDate = DateTime.Parse(Q2 + year);
                        endDate = DateTime.Parse(Q3 + year);
                        break;
                    case ("Q3"):
                        startDate = DateTime.Parse(Q3+year);
                        endDate = DateTime.Parse(Q4 + year);
                        break;
                    case ("Q4"):
                        startDate = DateTime.Parse(Q4 + year);
                        endDate = DateTime.Parse(Q1 + (year + 1));
                        break;
                    default:
                        startDate = DateTime.Now;
                        endDate = DateTime.Now;
                        break;
                }
                var sales = this.saleRepo.GetAllForSalespersonId(s.SalespersonId);
                var quarterlySales = GetSalesBetweenDates(sales, startDate, endDate);
                if (quarterlySales.Any())
                {
                    commissionReportEntities.Add(new CommissionReportEntity
                    {
                        SalespersonName = s.FirstName + " " + s.LastName,
                        SalesNumber = quarterlySales.Count,
                        CommissionTotal = GetCommissionMade(quarterlySales)
                    });
                }
            }
            return commissionReportEntities;
        }

        private decimal GetCommissionMade(IList<Sale> sales)
        {
            decimal total = 0;
            foreach(Sale s in sales)
            {
                var product = this.productRepo.FindById(s.ProductId);
                if(product.CommissionPercentage != null)
                {
                    total += (decimal)(product.PurchasePrice * (product.CommissionPercentage / 100));
                }
            }
            return total;
        }

        private IList<Sale> GetSalesBetweenDates(IList<Sale> providedSales, DateTime beginDate, DateTime endDate)
        {
            var salesList = new List<Sale>();
            foreach (Sale s in providedSales)
            {
                if (s.SalesDate > beginDate && s.SalesDate < endDate)
                {
                    salesList.Add(s);
                }
            }
            return salesList;
        }
    }
}
