using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Polo.Framework.ApplicationService;
using Polo.Framework.Core.Persistence;
using Polo.Framework.Core.Security;
using Polo.Framework.DependencyInjection;
using Polo.Framework.Domain;
using Polo.Framework.Facade;
using Polo.Framework.Persistence;
using Polo.Framework.Security;
using Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste;
using Polo.Shop.CustomerContext.Domain.Services.CustomerAggregate;
using Polo.Shop.CustomerContext.Facade;
using Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate;
using Polo.Shop.Persistence;

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

         ///register DbContext service
         container.Register(Component
                           .For<DbContextBase>()
                           .ImplementedBy<ShopDbContext>()
                           .LifestyleScoped());


         ///register services for "ApplicationServices layer"
         container.Register(Classes
                           .FromAssemblyContaining<SignupCommandHandler>()
                           .BasedOn(typeof(ICommandHandler<>))
                           .WithServiceAllInterfaces()
                           .LifestyleScoped());

         ///register Services for "Facade layer"
         container.Register(Classes
                          .FromAssemblyContaining<CustomerCommandFacade>()
                          .BasedOn(typeof(FacadeCommandBase))
                          .WithServiceAllInterfaces()
                          .LifestyleScoped());

         ///Register service "DomainServices  layer"
         container.Register(Classes
                          .FromAssemblyContaining<NationalCodeDublicationChecker>()
                          .BasedOn(typeof(IDomainService))
                          .WithServiceAllInterfaces()
                          .LifestyleScoped());

         ///Register services(repositories) for "Persistence layer"
         container.Register(Classes
                          .FromAssemblyContaining<CustomerRepository>()
                          .BasedOn(typeof(IRepository<>))
                          .WithServiceAllInterfaces()
                          .LifestyleScoped());



      }
   }
}
