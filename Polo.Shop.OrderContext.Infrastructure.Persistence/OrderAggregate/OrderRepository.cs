using Polo.Framework.Persistence;
using Polo.Shop.OrderContext.Domain.OrderAggregate;
using Polo.Shop.OrderContext.Domain.OrderAggregate.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Infrastructure.Persistence.OrderAggregate
{
   public class OrderRepository : IOrderRepository
   {
      private readonly DbContextBase _context;
      public OrderRepository(DbContextBase context)
      {
         _context = context;
      }
      public void Create(Order order)
      {
         throw new NotImplementedException();
      }

      public int GenerateOrderNumber()
      {
         throw new NotImplementedException();
      }
   }
}
