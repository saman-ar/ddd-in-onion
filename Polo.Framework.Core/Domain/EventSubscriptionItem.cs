using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Polo.Framework.Core.Domain
{
   internal class EventSubscriptionItem
   {
      public EventSubscriptionItem()
      {
         Handlers = new List<EventHandler>();
      }

      public Type EventType { get; set; }
      public IList<EventHandler> Handlers { get; set; }
   }

   public class EventHandler
   {
      private readonly Action<object> _handlingAction;
      public EventHandler(Action<object> handlingAction)
      {
         _handlingAction = handlingAction;
      }

      public Action<object> Action => _handlingAction;
   }
}
