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
            var salesList = new List<Sale>();
            foreach (Sale s in this.Context.Sales)
            {
                if (s.SalesDate > beginDate && s.SalesDate < endDate)
                {
                    salesList.Add(s);
                }
            }
            return salesList;
        }

        public async Task<bool> CreateAsync(Sale newSale)
        {
            this.Context.Sales.Add(newSale);
            return await this.Context.SaveChangesAsync() == 1;
        }

        public IList<Sale> GetAllForSalespersonId(Guid salespersonId)
        {
            return this.Context.Sales.Where(s => s.SalespersonId == salespersonId).ToList();
        }
    }
}
