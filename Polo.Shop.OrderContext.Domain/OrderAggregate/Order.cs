using Polo.Framework.Domain;
using Polo.Shop.OrderContext.Domain.Contracts.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Polo.Shop.OrderContext.Domain.OrderAggregate
{
   public class Order : EntityBase, IAggregateRoot<Order>
   {
      public Order(int number, IEnumerable<OrderItem> cart)
      {
         Number = number;
         SetCart(cart);
         var score= CaculateScore();
         EventBus.Publish<OrderCreatedEvent>(new OrderCreatedEvent(Id, score));
      }


      public int Number { get; private set; }
      public decimal Tax { get; private set; }
      public decimal ShippingCost { get; private set; }
      public decimal TotalAmount { get; private set; }
      public ICollection<OrderItem> Cart { get; private set; }

      private void SetCart(IEnumerable<OrderItem> cart)
      {
         if (!cart.Any()) 
         {
            // throw exception
         }

         var orderItems = cart.Select(c => new OrderItem(c.ProductId, c.Quantity, c.Price));
         Cart.ToList().AddRange(orderItems);

         CalculateMount();
      }

      private void CalculateMount()
      {
         var subTotal = Cart.Sum(c => c.Quantity * c.Price);
         var ShippingCost = subTotal < 10000 ? 0 : 10000;
         Tax = (subTotal + ShippingCost) * (decimal)0.13;
         TotalAmount = subTotal + Tax + ShippingCost;
      }
      private int CaculateScore()
      {
         if (TotalAmount < 100000)
            return 1;

         if (TotalAmount < 200000)
            return 2;

         if (TotalAmount < 5000000)
            return 5;

         return 10;
      }

      public IEnumerable<Expression<Func<Order, dynamic>>> GetIncludeExpression()
      {
         yield return o => o.Cart;
      }

   }
}
