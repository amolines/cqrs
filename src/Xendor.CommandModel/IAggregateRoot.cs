using System.Collections.Generic;
using Xendor.CommandModel.Validation;
using Xendor.EventBus;

namespace Xendor.CommandModel
{
    /// <summary>
    ///
    /// <remarks>
    /// Domain Model Validation: An AGGREGATE root is responsible for coordinating the validation for the entire AGGREGATE,
    /// if a rule involves more than one AGGREGATE then it should be performed in a SERVICE (Application services)
    /// </remarks>
    /// </summary>
    public interface IAggregateRoot : IAggregateMember 
    {
        int Version { get; }

        IEnumerable<Event> UncommittedChanges { get; }

        string CollectionName { get; }

        INotification Notification { get; }
    }
}
