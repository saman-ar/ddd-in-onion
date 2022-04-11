using Polo.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Polo.Shop.OrderContext.Domain.OrderAggregate
{
   public class Order : EntityBase, IAggregateRoot<Order>
   {
      public Order(int number)
      {
         Number = number;
      }
      public int Number { get; set; }
      public decimal Tax { get; set; }
      public decimal ShippingCost { get; set; }
      public decimal TotalAmount { get; set; }
      public ICollection<OrderItem> Cart { get; set; }

      public void AddOrderItem(Guid productId, int quantity, decimal price)
      {
         Cart.Add(new OrderItem
         {
            ProductId = productId,
            Quantity = quantity,
            Price = price
         });

         CalculateMount();

      }
            
      public IEnumerable<Expression<Func<Order, dynamic>>> GetIncludeExpression()
      {
         yield return o => o.Cart;
      }

      private void CalculateMount()
      {
         var subTotal = Cart.Sum(c => c.Quantity * c.Price);
         var ShippingCost = subTotal < 10000 ? 0 : 10000;
         Tax = (subTotal + ShippingCost) * (decimal)0.13;
         TotalAmount = subTotal + Tax + ShippingCost;
      }
   }
}
