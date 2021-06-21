using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class SaleRepository : BaseRepository
    {
        public SaleRepository(BeSpokedDbContext context)
            : base(context)
        {
        }

        public IList<Sale> GetAll()
        {
            return this.Context.Sales.Local;
        }

        public IList<Sale> GetAllBetweenDates(DateTime beginDate, DateTime endDate)
        {
            if(beginDate.Date < endDate.Date)
            {
                return this.Context.Sales.Local.Where(s => (s.SalesDate.Date > beginDate.Date && s.SalesDate.Date < endDate.Date)).ToList();
            }
            else if(beginDate.Date > endDate.Date)
            {
                return this.Context.Sales.Local.Where(s => (s.SalesDate.Date < beginDate.Date && s.SalesDate.Date > endDate.Date)).ToList();
            }
            else
            {
                return this.Context.Sales.Local.Where(s => (s.SalesDate.Date == beginDate.Date)).ToList();
            }
        }

        public async Task<bool> CreateAsync(Sale newSale)
        {
            this.Context.Sales.Add(newSale);
            return await this.Context.SaveChangesAsync() == 1;
        }
    }
}
