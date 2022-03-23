using Polo.Framework.Core.ApplicationService;
using System;

namespace Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate
{
   public class AddAddressCommand :Command
    {


        public string PostalCode { get; private set; }
        public string AddressLine { get; private set; }
        public int CityId { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Telephone { get; set; }
        public string Coordinate { get; set; }
    }
}
