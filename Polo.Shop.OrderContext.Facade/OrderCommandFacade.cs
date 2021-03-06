using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Facade;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate;
using Polo.Shop.OrderContext.ApplicationService.OrderAggregate;
using Polo.Shop.OrderContext.Domain.Contracts.OrderAggregate;
using Polo.Shop.OrderContext.Facade.Contracts;
using System;
using System.Collections.Generic;

namespace Polo.Shop.OrderContext.Facade
{
   public class OrderCommandFacade : FacadeCommandBase, IOrderCommandFacade
   {
      public OrderCommandFacade(ICommandBus commandBus) : base(commandBus)
      { }

      public void CreateOrder(CreateOrderCommand command)
      {
         var score = 0;
         EventBus.Subscribe<OrderCreatedEvent>(e => score = e.CustomerScore);
         CommandBus.Dispatch<CreateOrderCommand>(command);

         var updateScoreCommand = new UpdateScoreCommand() { CustomerId=command.CustomerId , Score= score };
         CommandBus.Dispatch<UpdateScoreCommand>(updateScoreCommand);
      }
   }
}
