using System.Collections.Generic;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(BeSpokedDbContext context)
            : base(context)
        {
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var foundProduct = await this.Context.Products.FindAsync(product.ProductId);
            if(foundProduct != null)
            {
                foundProduct = product;
                return await this.Context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public IList<Product> GetProducts()
        {
            return this.Context.Products.Local;
        }
    }
}
