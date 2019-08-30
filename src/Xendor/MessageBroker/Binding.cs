using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xendor.MessageBroker
{
    public class Binding
    {
        private readonly IList<Argument> _arguments;
        public Binding()
        {
            _arguments = new List<Argument>();
        }
        public void AddArgument(Argument argument)
        {
            if (!_arguments.Any(a => a.Name.Equals(argument.Name)))
                _arguments.Add(argument);
        }
        public Argument this[string name]
        {
            get { return _arguments.FirstOrDefault(a=>a.Name.Equals(name)); }
        }
        public IEnumerable<Argument> Arguments => new ReadOnlyCollection<Argument>(_arguments);
    }
}