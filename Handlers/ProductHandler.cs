using System.Collections.Generic;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;

namespace BespokedBikesTimHawkins.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly ProductRepository productRepo;

        public ProductHandler(ProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        public IList<Product> GetProducts()
        {
            try
            {
                return this.productRepo.GetAll();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateProductAsync(Product updatedProduct
            )
        {
            try
            {
                return await this.productRepo.UpdateAsync(updatedProduct);
            }
            catch
            {
                return false;
            }
        }
    }
}
