using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Facade;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;

namespace Polo.Shop.CustomerContext.Facade
{
   public class CustomerCommandFacade : FacadeCommandBase
   {
      public CustomerCommandFacade(ICommandBus commandBus):base(commandBus)
      {     }

      void Signup(SignupCommand command)
      {
         CommandBus.Dispatch<SignupCommand>(command); 
      }

      void AddAddress(AddAddressCommand command)
      {
         CommandBus.Dispatch<AddAddressCommand>(command);
      }

   }
}
