using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Polo.Framework.ApplicationService;
using Polo.Framework.Core.Security;
using Polo.Framework.DependencyInjection;
using Polo.Framework.Facade;
using Polo.Framework.Security;
using Polo.Shop.CustomerContext.AppliactionService.CustomerAggregste;
using Polo.Shop.CustomerContext.Facade;
using System;

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




      }
   }
}
