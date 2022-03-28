using Polo.Framework.Domain;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;
using System.Linq;

namespace Polo.Shop.CustomerContext.Domain.Services.CustomerAggregate
{
   public class NationalCodeDublicationChecker : INationalCodeDublicationChecker ,IDomainService
   {
      private readonly ICustomerRepository _repository;
      public NationalCodeDublicationChecker(ICustomerRepository repository)
      {
         _repository = repository;
      }

      public bool IsDublicated(string nationalCode)
      {
         return _repository.Contains(c => c.NationalCode == nationalCode);

      }
   }
}
