using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xendor.CommandModel.Validation
{
    public class ErrorCollection 
    {
        private readonly Error[] _brokenDomainRules;
        public ErrorCollection(Error[] brokenDomainRules)
        {
            _brokenDomainRules = new Error[brokenDomainRules.Length];
            brokenDomainRules.CopyTo(_brokenDomainRules,0);
        }
        public string[] GetErrors() => _brokenDomainRules.Select(m => m.Text).ToArray();
        public IEnumerable<Error> BrokenDomainRules => new ReadOnlyCollection<Error>(_brokenDomainRules);
        public int Errors => _brokenDomainRules.Length;
    }
}