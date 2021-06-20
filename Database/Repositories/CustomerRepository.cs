using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class CustomerRepository: BaseRepository
    {
        public CustomerRepository(BeSpokedDbContext context)
            : base(context)
        {
        }

        public IList<Customer> GetCustomers()
        {
            return this.Context.Customers.Local;
        }
    }
}
