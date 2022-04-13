using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Framework.Core.Domain
{
   public interface IEventBus
   {
      void Publish<TEvent>(TEvent domainEvent);
      void Subscribe<TEvent>(Action<dynamic> action) ;
   }
}
