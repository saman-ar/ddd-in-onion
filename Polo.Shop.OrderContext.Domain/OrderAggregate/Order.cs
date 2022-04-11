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
      public Order(int number , IEnumerable<OrderItem> cart)
      {
         Number = number;
         SetCart(cart);
      }
            
      public int Number { get; set; }
      public decimal Tax { get; set; }
      public decimal ShippingCost { get; set; }
      public decimal TotalAmount { get; set; }
      public ICollection<OrderItem> Cart { get; set; }

      private void AddOrderItem(Guid productId, int quantity, decimal price)
      {
         Cart.Add(new OrderItem
         {
            ProductId = productId,
            Quantity = quantity,
            Price = price
         });

         CalculateMount();

      }
       
      private void SetCart(IEnumerable<OrderItem> cart)
      {
         if (!cart.Any()) // or any negative logic
         {
            // throw exception
         }

         foreach (var item in cart)
         {
            AddOrderItem(item.ProductId, item.Quantity, item.Price);
         }
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
