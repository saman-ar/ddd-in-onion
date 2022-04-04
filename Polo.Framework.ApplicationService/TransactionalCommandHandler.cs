using Polo.Framework.Core.ApplicationService;
using Polo.Framework.Core.DependencyInjection;
using Polo.Framework.Persistence;

namespace Polo.Framework.ApplicationService
{
   public class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
   {
      private readonly ICommandHandler<TCommand> _commandHandler;
      public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler)
      {
         _commandHandler = commandHandler;
      }
      public void Execute(TCommand command)
      {
         var unitOfWork = ServiceLocator.Current.Resolve<IUnitOfWork>();

         try
         {
            _commandHandler.Execute(command);
            unitOfWork.Commit();
         }
         catch 
         {
            unitOfWork.RollBack();
            throw;
         }

      }
   }

}
