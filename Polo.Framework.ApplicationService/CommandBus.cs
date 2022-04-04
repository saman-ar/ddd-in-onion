using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Core.DependencyInjection;

namespace Polo.Framework.ApplicationService
{
   public class CommandBus : ICommandBus
   {
      public void Dispatch<TCommand>(TCommand command) where TCommand : Command
      {
         var commandHandler = ServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();

         var transactionalDecorator = new TransactionalCommandHandler<TCommand>(commandHandler);
         var logDecorator = new LogCommandHandler<TCommand>(transactionalDecorator);
         var ExceptionControllingDecorator = new ExceptionCommandHandler<TCommand>(logDecorator);

         ExceptionControllingDecorator.Execute(command);
      }
   }
}