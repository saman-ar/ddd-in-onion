using Polo.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Domain.OrderAggregate
{
   public class OrderItem : EntityBase
   {
      public OrderItem(Guid productId, int quantity, decimal price)
      {
         ProductId = productId;
         Quantity = quantity;
         Price = price;
      }

      public Guid ProductId { get; private set; }
      public int Quantity { get; private set; }
      public decimal Price { get; private set; }

   }
}
