using System.Collections.Generic;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;

namespace BespokedBikesTimHawkins.Handlers
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly CustomerRepository customerRepo;

        public CustomerHandler(CustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IList<Customer> GetCustomers()
        {
            try
            {
                return this.customerRepo.GetAll();
            }
            catch
            {
                return null;
            }
        }
    }
}
