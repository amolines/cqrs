using System;
using System.Collections.Generic;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Command
{
    public interface IValidationHandler<in TCommand> : ITransientLifestyle, IDisposable
        where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}