using Polo.Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate
{
   public class CreateOrderCommand : Command
   {
     public IList<OrderItem> Cart { get; set; }
   }
}
