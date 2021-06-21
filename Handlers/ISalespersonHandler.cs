using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.UI;

namespace BespokedBikesTimHawkins.Handlers
{
    public interface ISalespersonHandler
    {
        /// <summary>
        /// Gets all salespeople
        /// </summary>
        /// <returns> List of all salespeople </returns>
        IList<Salesperson> GetSalespeople();

        /// <summary>
        /// Updates an existing salesperson entity in the database
        /// </summary>
        /// <param name="updatedSalesperson"> The updated salesperson </param>
        /// <returns></returns>
        Task<bool> UpdateSalespersonAsync(Salesperson updatedSalesperson);
    }
}
