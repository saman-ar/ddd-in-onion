using Polo.Framework.ApplicationService;
using Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate;
using Polo.Shop.OrderContext.Domain.OrderAggregate;
using Polo.Shop.OrderContext.Domain.OrderAggregate.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.OrderContext.ApplicationService.OrderAggregate
{

   public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
   {
      private readonly IOrderRepository _orderRepository;

      public CreateOrderCommandHandler(IOrderRepository orderRepository)
      {
         _orderRepository = orderRepository;
      }

      public void Execute(CreateOrderCommand command)
      {
         int orderNumber=_orderRepository.GenerateOrderNumber();

         var order = new Order(orderNumber);

         foreach (var item in command.Cart)
         {
            order.AddOrderItem(item.ProductId, item.Quantity, item.Price);
         }

         _orderRepository.Create(order);
      }
   }
}
