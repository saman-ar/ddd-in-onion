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


      public void Publish<TEvent>(TEvent domainEvent) where TEvent : IEvent
      {
         ///refactored
         //subscriptionList.SingleOrDefault(l => l.EventType == typeof(TEvent)).Handlers.ForEach(h => h.Action(domainEvent));
         //FindExistingType<TEvent>().Handlers.ForEach(h => h.Action(domainEvent));

         var existingEvent = FindExistingType<TEvent>();
         if (existingEvent != null)
         {
            foreach (var doAction in existingEvent.Handlers)
            {
               doAction(domainEvent);
            }
         }
      }

      public void Subscribe<TEvent>(Action<IEvent> action) where TEvent : IEvent
      {
         var existingEvent = FindExistingType<TEvent>();

         if (existingEvent == null)
         {
            var newSubscription = new EventSubscriptionItem();
            newSubscription.Handlers.Add(action);
            newSubscription.EventType = typeof(TEvent);

            subscriptionList.Add(newSubscription);
         }
         else
         {
            existingEvent.Handlers.Add(action);
         }
      }

      private EventSubscriptionItem FindExistingType<TEvent>()
      {
         return subscriptionList.SingleOrDefault(item => item.EventType == typeof(TEvent));
      }
   }
}
