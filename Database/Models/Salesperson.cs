using System;

namespace BespokedBikesTimHawkins.Database.Models
{
    public class Salesperson
    {
        public Guid SalespersonId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Manager { get; set; }
    }
}
