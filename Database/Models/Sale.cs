using System;

namespace BespokedBikesTimHawkins.Database.Models
{
    public class Sale
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SalespersonId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
