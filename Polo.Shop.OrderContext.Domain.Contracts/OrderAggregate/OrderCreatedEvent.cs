using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Domain.Contracts.OrderAggregate
{
   public class OrderCreatedEvent
   {
      public OrderCreatedEvent(Guid OrderId, int customerScore)
      {
         this.OrderId = OrderId;
         CustomerScore = customerScore;
      }
      public Guid OrderId { get;private set; }
      public int CustomerScore { get; private set; }
   }
}
