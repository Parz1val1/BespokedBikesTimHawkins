//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BespokedBikesTimHawkins.Database.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Discount
    {
        public System.Guid ProductId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int DiscountPercentage { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
