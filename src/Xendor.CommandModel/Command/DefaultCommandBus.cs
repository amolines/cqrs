using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendor.CommandModel.Command
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandFactory;
        public DefaultCommandBus(ICommandHandlerFactory commandFactory)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        }

        public Task<ICommandResult> Submit<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _commandFactory.CreateCommandHandler<TCommand>();
            var result = handler.Handle(command);
            return result;
        }

        public IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _commandFactory.CreateValidationHandler<TCommand>();
            var result = handler.Validate(command);
            handler.Dispose();
            return result;
        }
    }
}