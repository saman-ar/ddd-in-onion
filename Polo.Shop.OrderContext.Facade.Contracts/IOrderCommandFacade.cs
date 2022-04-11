using Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.Facade.Contracts
{
   public interface IOrderCommandFacade
   {

      void CreateOrder(CreateOrderCommand command);


   }
}
