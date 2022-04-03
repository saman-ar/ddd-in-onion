using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;
using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate
{
   public class CustomerRepository : RepositoryBase<Customer> , ICustomerRepository
   {

      public CustomerRepository(DbContextBase context):base(context)
      {      }

      public void CreateCustomer(Customer customer)
      {
         Set.Add(customer);

         _context.SaveChanges();
      }

      public void Update(Customer customer)
      {
         throw new NotImplementedException();
      }

      public bool Contains(Expression<Func<Customer, bool>> predicate)
      {
         return SetWithIncludeExpressions.Any(predicate);
      }


   }
}
