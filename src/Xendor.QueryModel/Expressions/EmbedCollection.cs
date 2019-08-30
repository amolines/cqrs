using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xendor.QueryModel.Expressions
{
    public class EmbedCollection
    {
        private readonly List<Embed> _embeds;
        public EmbedCollection()
        {
            _embeds = new List<Embed>();
        }

        internal void Add(string name, Type type)
        {
            var filter = new Embed(name, type);
            _embeds.Add(filter);
        }
        public IEnumerable<Embed> Embeds => new ReadOnlyCollection<Embed>(_embeds);
        public override string ToString()
        {
            var filters = string.Join(",", _embeds.Select(f => f.Name));
            return filters;
        }

        public bool Any()
        {
            return _embeds.Any();
        }
        public bool Any(string name)
        {
            return _embeds.Any(e=>e.Name.Equals(name));
        }
    }
}