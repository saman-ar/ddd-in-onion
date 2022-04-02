using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Polo.Framework.ApplicationService;
using Polo.Framework.Core.Persistence;
using Polo.Framework.Core.Security;
using Polo.Framework.DependencyInjection;
using Polo.Framework.Domain;
using Polo.Framework.Facade;
using Polo.Framework.Security;
using Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste;
using Polo.Shop.CustomerContext.Domain.Services.CustomerAggregate;
using Polo.Shop.CustomerContext.Facade;
using Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate;

namespace Polo.Shop.CustomerContext.Configuration
{
   public class Registrar : IRegistrar
   {
      public void Register(WindsorContainer container)
      {
         ///register tools for "any layer"
         container.Register(Component
                           .For<IPasswordHasher>()
                           .ImplementedBy<PasswordHasher>()
                           .LifestyleSingleton());

         ///register services for "ApplicationServices layer"
         container.Register(Classes
                           .FromAssemblyContaining<SignupCommandHandler>()
                           .BasedOn(typeof(ICommandHandler<>))
                           .WithServiceAllInterfaces()
                           .LifestyleTransient());

         ///register Services for "Facade layer"
         container.Register(Classes
                          .FromAssemblyContaining<CustomerCommandFacade>()
                          .BasedOn(typeof(FacadeCommandBase))
                          .WithServiceAllInterfaces()
                          .LifestyleTransient());

         ///Register service "DomainServices  layer"
         container.Register(Classes
                          .FromAssemblyContaining<NationalCodeDublicationChecker>()
                          .BasedOn(typeof(IDomainService))
                          .WithServiceAllInterfaces()
                          .LifestyleTransient());

         ///Register services(repositories) for "Persistence layer"
         container.Register(Classes
                          .FromAssemblyContaining<CustomerRepository>()
                          .BasedOn(typeof(IRepository))
                          .WithServiceAllInterfaces()
                          .LifestyleTransient());




      }
   }
}
