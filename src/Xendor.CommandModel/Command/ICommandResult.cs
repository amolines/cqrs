using System;
using System.Collections.Generic;
using Xendor.CommandModel.Validation;

namespace Xendor.CommandModel.Command
{
    public interface ICommandResult
    {
        Guid AggregateId { get; }
        bool Success { get; }

        IEnumerable<Error> Errors { get; }
    }
}