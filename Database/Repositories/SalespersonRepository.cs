using System.Collections.Generic;
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
            var foundSalesperson = await this.Context.Salespersons.FindAsync(salesperson.SalespersonId);
            if (foundSalesperson != null)
            {
                foundSalesperson = salesperson;
                return await this.Context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public IList<Salesperson> GetSalespersons()
        {
            return this.Context.Salespersons.Local;
        }
    }
}
