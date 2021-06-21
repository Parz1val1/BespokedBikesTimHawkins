using System.Collections.Generic;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;

namespace BespokedBikesTimHawkins.Handlers
{
    class SalespersonHandler : ISalespersonHandler
    {
        private readonly SalespersonRepository salespersonRepo;

        public SalespersonHandler(SalespersonRepository salespersonRepo)
        {
            this.salespersonRepo = salespersonRepo;
        }

        public IList<Salesperson> GetSalespeople()
        {
            try
            {
                return this.salespersonRepo.GetAll();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateSalespersonAsync(Salesperson updatedSalesperson)
        {
            try
            {
                return await this.salespersonRepo.UpdateAsync(updatedSalesperson);
            }
            catch
            {
                return false;
            }
        }
    }
}
