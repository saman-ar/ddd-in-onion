using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate
{
   public class OrderItem
   {
      public Guid ProductId { get; set; }
      public int Quantity { get; set; }
      public decimal Price { get; set; }
   }
}
