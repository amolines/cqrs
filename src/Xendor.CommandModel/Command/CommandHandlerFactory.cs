using System;
using Xendor.CommandModel.Command.Exceptions;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Command
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IDependencyResolver _serviceProvider;

        public CommandHandlerFactory(IDependencyResolver serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public ICommandHandler<TCommand> CreateCommandHandler<TCommand>()
            where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
            return handler;
        }

        public IValidationHandler<TCommand> CreateValidationHandler<TCommand>()
            where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService<IValidationHandler<TCommand>>();
            if (handler == null)
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }
            return handler;
        }
    }
}