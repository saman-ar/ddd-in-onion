using Polo.Framework.Core.Domain;
using System;

namespace Polo.Shop.OrderContext.Domain.Contracts.OrderAggregate
{
   public class OrderCreatedEvent :IEvent
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
