using System;
using System.Collections.Generic;
using System.Linq;
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
            var foundProduct = this.Context.Products.Where(p => p.ProductId == product.ProductId).SingleOrDefault();
            if (foundProduct != null)
            {
                foundProduct.Name = product.Name;
                foundProduct.Manufacturer = product.Manufacturer;
                foundProduct.Style = product.Style;
                foundProduct.PurchasePrice = product.PurchasePrice;
                foundProduct.SalePrice = product.SalePrice;
                foundProduct.QtyOnHand = product.QtyOnHand;
                foundProduct.CommissionPercentage = product.CommissionPercentage;
                return await this.Context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public IList<Product> GetAll()
        {
            return this.Context.Products.Local;
        }

        public Product FindById(Guid productId)
        {
            return Context.Products.Where(p => p.ProductId == productId).SingleOrDefault();
        }
    }
}
