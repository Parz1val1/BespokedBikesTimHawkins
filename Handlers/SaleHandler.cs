using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;

namespace BespokedBikesTimHawkins.Handlers
{
    public class SaleHandler : ISaleHandler
    {
        private readonly SaleRepository saleRepo;

        public SaleHandler(SaleRepository saleRepo)
        {
            this.saleRepo = saleRepo;
        }

        public async Task<bool> CreateSaleAsync(Sale newSale)
        {
            try
            {
                return await this.saleRepo.CreateAsync(newSale);
            }
            catch
            {
                return false;
            }
        }

        public IList<Sale> GetSales()
        {
            try
            {
                return this.saleRepo.GetAll();
            }
            catch
            {
                return null;
            }
        }

        public IList<Sale> GetSalesBetweenDates(DateTime beginDate, DateTime endDate)
        {
            try
            {
                return this.saleRepo.GetAllBetweenDates(beginDate, endDate);
            }
            catch
            {
                return null;
            }
        }
    }
}
