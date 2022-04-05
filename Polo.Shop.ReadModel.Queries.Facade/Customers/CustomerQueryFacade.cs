using Polo.Shop.ReadModel.Context.Models;
using Polo.Shop.ReadModel.Queries.Contracts.Customers;
using Polo.Shop.ReadModel.Queries.Contracts.Customers.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Polo.Shop.ReadModel.Queries.Facade.Customers
{
   class CustomerQueryFacade : ICustomerQueryFacade
   {
      public IList<CustomerDto> GetCustomers(string keyword)
      {
         using (var _context2 = new PoloShopContext())
         {

            // Expression<Func<Customer, bool>> predicate = new Expression<Func<Customer, bool>>();

            return _context2.Customer
                  .Where(
                           c => c.FirstName.Contains(keyword) ||
                           c.LastName.Contains(keyword) ||
                           c.Email.Contains(keyword)
                        )
                  .Select
                  (
                        c => new CustomerDto
                        {
                           Id = c.Id,
                           FirstName = c.FirstName,
                           LastName = c.LastName,
                           Email = c.Email,
                           HasAddress = c.Address.Any()
                        }
                  )
                  .ToList();
         }

         //using (var _context = new PoloShopContext())
         //{
         //   return (from customer in _context.Customer
         //           let HasAddress=customer.Address.Any()
         //           select new CustomerDto
         //           {
         //              Id=customer.Id,
         //              FirstName=customer.FirstName,
         //              LastName=customer.LastName,
         //              Email=customer.Email
         //           }).ToList();
         //}


      }
   }
}
