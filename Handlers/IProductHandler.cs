using System.Collections.Generic;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Handlers
{
    public interface IProductHandler
    {
        /// <summary>
        /// Gets a list of all Products
        /// </summary>
        /// <returns>List of all current Products</returns>
        IList<Product> GetProducts();

        /// <summary>
        /// Updates an existing Product entity in the database
        /// </summary>
        /// <param name="updatedProduct"> The updated product </param>
        /// <returns> Whether the update was successful or not </returns>
        Task<bool> UpdateProductAsync(Product updatedProduct);
    }
}
