using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Handlers
{
    public interface ISaleHandler
    {
        /// <summary>
        /// Gets a list of all sales from the database
        /// </summary>
        /// <returns> List of all sales </returns>
        IList<Sale> GetSales();

        /// <summary>
        /// Gets a list of all sales betwen two dates
        /// </summary>
        /// <param name="beginDate"> The date to start the search at </param>
        /// <param name="endDate"> The date to end the search at </param>
        /// <returns> List of sales between the two dates </returns>
        IList<Sale> GetSalesBetweenDates(DateTime beginDate, DateTime endDate);

        /// <summary>
        /// Adds a new sale entity to the database
        /// </summary>
        /// <param name="newSale"> The sale to add to the database </param>
        /// <returns> Whether the addition of the new entity was successful </returns>
        Task<bool> CreateSaleAsync(Sale newSale);
    }
}
