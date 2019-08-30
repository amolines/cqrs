using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Command
{
    public interface ICommandHandlerFactory : ISingletonLifestyle
    {
        ICommandHandler<TCommand> CreateCommandHandler<TCommand>()
            where TCommand : ICommand;

        IValidationHandler<TCommand> CreateValidationHandler<TCommand>()
            where TCommand : ICommand;
    }
}