using Polo.Framework.Core.ApplicationService;
using System;

namespace Polo.Framework.ApplicationService
{
    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    } 
}

