using Polo.Framework.ApplicationService;
using Polo.Shop.OrderContext.ApplicationService.Contracts.OrderAggregate;
using Polo.Shop.OrderContext.Domain.OrderAggregate;
using Polo.Shop.OrderContext.Domain.OrderAggregate.Services;
using System.Linq;
using OrderItem = Polo.Shop.OrderContext.Domain.OrderAggregate.OrderItem;

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

         var cart = command.Cart.Select(c => new OrderItem(c.ProductId,c.Quantity,c.Price));

         var order = new Order(orderNumber,cart);

         _orderRepository.Create(order);
      }
   }
}
