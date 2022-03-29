using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate
{
   public class CustomerRepository : ICustomerRepository

   {
      public bool Contains(Expression<Func<Customer, bool>> predicate)
      {
         throw new NotImplementedException();
      }

      public void CreateCustomer(Customer customer)
      {
         throw new NotImplementedException();
      }

      public Customer GetById(Guid customerId)
      {
         throw new NotImplementedException();
      }

      public void Update(Customer customer)
      {
         throw new NotImplementedException();
      }
   }
}
