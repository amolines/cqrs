using System.Collections.Generic;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Command
{
    public interface ICommandBus : ISingletonLifestyle
    {
        Task<ICommandResult> Submit<TCommand>(TCommand command)
            where TCommand : ICommand;
        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command)
             where TCommand : ICommand;
    }
}