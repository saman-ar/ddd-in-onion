using Polo.Framework.Core.ApplicationService;
using System;

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
         //begin transaction

         _commandHandler.Execute(command);

         //commit transaction
      }
   }

}
