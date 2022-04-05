using Polo.Shop.ReadModel.Queries.Contracts.Customers.DataContracts;
using System.Collections.Generic;

namespace Polo.Shop.ReadModel.Queries.Contracts.Customers
{
   public interface ICustomerQueryFacade
   {
      IList<CustomerDto> GetCustomers(string keyword);
   }
}
