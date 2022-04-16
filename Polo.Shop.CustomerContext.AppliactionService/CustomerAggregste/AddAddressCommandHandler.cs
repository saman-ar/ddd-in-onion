using Polo.Framework.ApplicationService;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;

namespace Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste
{

   class AddAddressCommandHandler : ICommandHandler<AddAddressCommand>
   {
      private readonly ICustomerRepository _customerRepository;
      public AddAddressCommandHandler(ICustomerRepository customerRepository)
      {
         _customerRepository = customerRepository;
      }
      public void Execute(AddAddressCommand command)
      {
         var customer = _customerRepository.GetById(command.CustomerId);

         var address = new Address(
                     command.PostalCode,
                     command.CustomerId,
                     command.CityId,
                     command.AddressLine);
         address.Telephone = command.Telephone;
         address.Coordinate = command.Coordinate;

         customer.AddAddress(address);

         _customerRepository.Update(customer);
      }
   }
}
