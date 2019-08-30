using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xendor.QueryModel.Expressions
{
    public class FullTextSearch
    {
        private List<string> _names;
        public FullTextSearch(List<string> names, string value)
        {
            _names = names;
            Value = value;
        }

        public IEnumerable<string> Name => new ReadOnlyCollection<string>(_names);
        public string Value { get; }
        public override string ToString()
        {
            return $"q={Value}";
        }
    }
}