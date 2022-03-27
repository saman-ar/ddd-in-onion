using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Facade;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using Polo.Shop.CustomerContext.Facade.Contracts;

namespace Polo.Shop.CustomerContext.Facade
{
   public class CustomerCommandFacade : FacadeCommandBase, ICustomerCommandFacade
   {
      public CustomerCommandFacade(ICommandBus commandBus) : base(commandBus)
      { }

      public void Signup(SignupCommand command)
      {
         CommandBus.Dispatch<SignupCommand>(command);
      }

      public void AddAddress(AddAddressCommand command)
      {
         CommandBus.Dispatch<AddAddressCommand>(command);
      }
   }
}
