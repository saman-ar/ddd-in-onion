using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;
using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate
{
   public class CustomerRepository : ICustomerRepository
   {

      private readonly DbContextBase _context;
      public CustomerRepository(DbContextBase context)
      {
         _context = context;
      }

      public void CreateCustomer(Customer customer)
      {
         _context.Set<Customer>().Add(customer);

         _context.SaveChanges();
      }

      public Customer GetById(Guid customerId)
      {
        return _context.Set<Customer>().Include(c=>c.Addresses).Single(c => c.Id == customerId);
      }

      public void Update(Customer customer)
      {
         throw new NotImplementedException();
      }

      public bool Contains(Expression<Func<Customer, bool>> predicate)
      {

      }
      

   }
}
