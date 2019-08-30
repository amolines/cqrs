using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xendor.Extensions.Collections.Generic;

namespace Xendor.CommandModel.Validation
{
    public class Notification : INotification
    {
        private readonly List<Error> _errors;
        public Notification()
        {
            _errors = new List<Error>();
        }
        public bool HasErrors => !_errors.IsEmpty();
        public IEnumerable<Error> Errors => new ReadOnlyCollection<Error>(_errors);
        public void AddError(Error error)
        {
            _errors.Add(error);
        }
        public void AddErrors(ErrorCollection errors)
        {
            _errors.AddRange(errors.BrokenDomainRules);
        }
        public void Clear()
        {
            _errors.Clear();
        }
    }
}