using Polo.Framework.Domain;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Exceptions;
using System;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate
{
   public class Address : EntityBase
   {
      private Address()
      { }
      public Address(string postalCode, Guid customerId, int cityId, string addressLine)
      {
         CustomerId = customerId;
         CityId = cityId;
         SetPostalCode(postalCode);
         SetAddressLine(addressLine);
      }


      public string PostalCode { get; private set; }
      public string AddressLine { get; private set; }
      public int CityId { get; private set; }
      public Guid CustomerId { get; private set; }
      public string Telephone { get; set; }
      public string Coordinate { get; set; }

      private void SetAddressLine(string addressLine)
      {
         if (string.IsNullOrWhiteSpace(addressLine))
            throw new AddressLineRequiredException();

         AddressLine = addressLine;
      }

      private void SetPostalCode(string postalCode)
      {
         if (string.IsNullOrWhiteSpace(postalCode))
            throw new PostalCodeRequiredException();

         PostalCode = postalCode;
      }
   }
}
