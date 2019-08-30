using System;
using System.Collections.Generic;
using Xendor.CommandModel.Validation;

namespace Xendor.CommandModel.Command
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(IEnumerable<Error> errors)
        {
            Success = false;
            Errors = errors;
        }
        public CommandResult(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Success = true;
        }
        public CommandResult(Guid aggregateId, IEnumerable<Error> errors)
        {
            AggregateId = aggregateId;
            Success = false;
            Errors = errors;
        }
       
       

        public Guid AggregateId { get; }
        public bool Success { get;  }
        public IEnumerable<Error> Errors { get; }
    }
}