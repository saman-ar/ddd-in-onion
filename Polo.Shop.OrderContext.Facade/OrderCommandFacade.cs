using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Facade;
using Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate;
using Polo.Shop.OrderContext.ApplicationService.OrderAggregate;
using Polo.Shop.OrderContext.Facade.Contracts;
using System;

namespace Polo.Shop.OrderContext.Facade
{
   public class OrderCommandFacade : FacadeCommandBase, IOrderCommandFacade
   {
      public OrderCommandFacade(ICommandBus commandBus):base(commandBus)
      {   }

      public void CreateOrder(CreateOrderCommand command)
      {
         CommandBus.Dispatch<CreateOrderCommand>(command);
      }
   }
}
