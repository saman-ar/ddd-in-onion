using System;

namespace Polo.Shop.ReadModel.Queries.Contracts.Customers.DataContracts
{
   public class CustomerDto
   {
      public Guid Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public bool HasAddress { get; set; }
   }
}
