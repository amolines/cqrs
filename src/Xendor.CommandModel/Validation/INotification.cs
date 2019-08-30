using System.Collections.Generic;

namespace Xendor.CommandModel.Validation
{
    public interface INotification
    {
        bool HasErrors { get; }

        IEnumerable<Error> Errors { get; }
    }
}