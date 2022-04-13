using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Polo.Framework.Core.Domain
{
   public class EventBus : IEventBus
   {
      private List<EventSubscriptionItem> subscriptionList;

      public EventBus()
      {
         subscriptionList = new List<EventSubscriptionItem>();
      }


      public void Publish<TEvent>(TEvent domainEvent)
      {
         ///refactored
         //subscriptionList.SingleOrDefault(l => l.EventType == typeof(TEvent)).Handlers.ForEach(h => h.Action(domainEvent));
         //FindExistingType<TEvent>().Handlers.ForEach(h => h.Action(domainEvent));

         var existingEvent = FindExistingType<TEvent>();
         if (existingEvent != null)
         {
            foreach (var handler in existingEvent.Handlers)
            {
               handler.Action(domainEvent);
            }
         }
      }

      public void Subscribe<TEvent>(Action<dynamic> action)
      {
         var existingEvent = FindExistingType<TEvent>();

         if (existingEvent == null)
         {
            var newSubscription = new EventSubscriptionItem();
            newSubscription.Handlers.Add(new EventHandler(action));
            newSubscription.EventType = typeof(TEvent);
            // Handlers = new List<EventHandler>() { new EventHandler(action) }

            subscriptionList.Add(newSubscription);
         }
         else
         {
            existingEvent.Handlers.Add(new EventHandler(action));
         }
      }

      private EventSubscriptionItem FindExistingType<TEvent>()
      {
         return subscriptionList.SingleOrDefault(item => item.EventType == typeof(TEvent));
      }
   }
}
