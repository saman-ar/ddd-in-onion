using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Framework.Core.Domain
{
   public interface IEventBus
   {
      void Publish<TEvent>(TEvent domainEvent)where TEvent : IEvent;
      void Subscribe<TEvent>(Action<IEvent> action) where TEvent : IEvent;
   }
}
