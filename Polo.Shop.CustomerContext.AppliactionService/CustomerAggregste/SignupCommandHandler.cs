using Polo.Framework.ApplicationService;
using Polo.Framework.Core.Security;
using Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;

namespace Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste
{
    public class SignupCommandHandler : ICommandHandler<SignupCommand>
    {
        private readonly INationalCodeDublicationChecker _nationalCodeDublicationChecker;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICustomerRepository _customerRepository;

        public SignupCommandHandler(
            INationalCodeDublicationChecker nationalCodeDublicationChecker,
            IPasswordHasher passwordHasher,
            ICustomerRepository customerRepository)
        {
            _nationalCodeDublicationChecker = nationalCodeDublicationChecker;
            _passwordHasher = passwordHasher;
        }

        public void Execute(SignupCommand command)
        {

            var customer = new Customer(
                    _nationalCodeDublicationChecker,
                    _passwordHasher,command.Email,
                    command.Password,
                    command.FirstName,
                    command.LastName,
                    command.NationalCode
                    );

            _customerRepository.CreateCustomer(customer);
        }
    }
}
