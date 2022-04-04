using Polo.Framework.Core.ApplicationService;

namespace Polo.Framework.ApplicationService
{
   class ExceptionCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
   {
      private readonly ICommandHandler<TCommand> _commandHandler;
      public ExceptionCommandHandler(ICommandHandler<TCommand> commandHandler)
      {
         _commandHandler = commandHandler;
      }
      public void Execute(TCommand command)
      {
         try
         {
            _commandHandler.Execute(command);
         }
         catch (System.Exception)
         {

           
         }
      }
   }
}
