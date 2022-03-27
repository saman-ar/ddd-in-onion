using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using System;

namespace Polo.Shop.CustomerContext.Facade.Contracts
{
   public interface ICustomerCommandFacade
   {
      void Signup(SignupCommand command);
      void AddAddress(AddAddressCommand command);
   }
}
