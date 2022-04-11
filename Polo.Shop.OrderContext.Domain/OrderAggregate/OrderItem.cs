using Polo.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Domain.OrderAggregate
{
   public class OrderItem :EntityBase
   {
      public Guid ProductId { get; set; }
      public int Quantity { get; set; }
      public decimal Price { get; set; }

   }
}
