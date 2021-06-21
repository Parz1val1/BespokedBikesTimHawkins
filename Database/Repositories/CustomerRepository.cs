using System.Collections.Generic;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class CustomerRepository: BaseRepository
    {
        public CustomerRepository(BeSpokedDbContext context)
            : base(context)
        {
        }

        public IList<Customer> GetAll()
        {
            return this.Context.Customers.Local;
        }
    }
}
