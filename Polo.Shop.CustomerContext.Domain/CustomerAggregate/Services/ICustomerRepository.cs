using Polo.Framework.Core.Persistence;
using System;
using System.Linq.Expressions;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services
{
   public interface ICustomerRepository : IRepository
   {
      void CreateCustomer(Customer customer);
      Customer GetById(Guid customerId);
      void Update(Customer customer);

      bool Contains(Expression<Func<Customer, bool>> predicate);
   }
}
