using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services
{
   public interface ICustomerRepository
   {
      void CreateCustomer(Customer customer);
      Customer GetById(Guid customerId);
      void Update(Customer customer);

      bool Contains(Expression<Func<Customer, bool>> predicate);
   }
}
