using Polo.Framework.ApplicationService;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;

namespace Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste
{
   class UpdateScoreCommandHandler : ICommandHandler<UpdateScoreCommand>
   {
      private readonly ICustomerRepository _customerRepository;
      public UpdateScoreCommandHandler(ICustomerRepository customerRepository)
      {
         _customerRepository = customerRepository;
      }

      public void Execute(UpdateScoreCommand command)
      {
         var customer = _customerRepository.GetById(command.CustomerId);
         customer.UpdateScore(command.Score);
      }

   }
}
