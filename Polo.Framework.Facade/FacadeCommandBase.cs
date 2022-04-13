using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Core.DependencyInjection;
using Polo.Framework.Core.Domain;
using System;

namespace Polo.Framework.Facade
{
   public abstract class FacadeCommandBase
   {
      public FacadeCommandBase(ICommandBus commandBus)
      {
         CommandBus = commandBus;
      }
      protected ICommandBus CommandBus { get; set; }

      protected IEventBus EventBus => ServiceLocator.Current.Resolve<IEventBus>();
   }
}
