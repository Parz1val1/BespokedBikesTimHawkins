using System.Collections.Generic;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Handlers
{
    public interface ICustomerHandler
    {
        /// <summary>
        /// Gets a list of all customers from database
        /// </summary>
        /// <returns> List of all customers </returns>
        IList<Customer> GetCustomers();
    }
}
