using Polo.Framework.Core.ApplicationService;
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
   }
}
