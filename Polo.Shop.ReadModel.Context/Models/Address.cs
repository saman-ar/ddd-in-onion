using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Polo.Shop.ReadModel.Context.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine { get; set; }
        public int CityId { get; set; }
        public Guid CustomerId { get; set; }
        public string Telephone { get; set; }
        public string Coordinate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
