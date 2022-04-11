using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Domain.OrderAggregate.Services
{
   public interface IOrderRepository
   {
      int GenerateOrderNumber();

      void Create(Order order);
   }
}
