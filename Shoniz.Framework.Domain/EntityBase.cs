using Polo.Framework.Core.DependencyInjection;
using Polo.Framework.Core.Domain;
using System;

namespace Polo.Framework.Domain
{
   public abstract class EntityBase
   {
      public EntityBase()
      {
         Id = Guid.NewGuid();
      }
      public Guid Id { get; private set; }
      public IEventBus EventBus => ServiceLocator.Current.Resolve<IEventBus>();
   }
}
