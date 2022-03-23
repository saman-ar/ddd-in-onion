using Polo.Framework.Core.ApplicationService;

namespace Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate
{
   public class SignupCommand :  Command
    {
        public string  Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }

    }
}
