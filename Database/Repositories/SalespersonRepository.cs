using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class SalespersonRepository : BaseRepository
    {
        public SalespersonRepository(BeSpokedDbContext context)
            : base(context)
        {
        }

        public async Task<bool> UpdateAsync(Salesperson salesperson)
        {
            var foundSalesperson = this.Context.Salespersons.SingleOrDefault(s => s.SalespersonId == salesperson.SalespersonId);
            if (foundSalesperson != null)
            {
                foundSalesperson.FirstName = salesperson.FirstName;
                foundSalesperson.LastName = salesperson.LastName;
                foundSalesperson.Address = salesperson.Address;
                foundSalesperson.Phone = salesperson.Phone;
                foundSalesperson.StartDate = salesperson.StartDate;
                foundSalesperson.TerminationDate = salesperson.TerminationDate;
                foundSalesperson.Manager = salesperson.Manager;

                return await this.Context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public IList<Salesperson> GetAll()
        {
            return this.Context.Salespersons.Local;
        }
    }
}
