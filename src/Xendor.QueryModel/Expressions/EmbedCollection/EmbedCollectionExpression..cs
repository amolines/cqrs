using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.EmbedCollection
{
    public class EmbedCollectionExpression<TMetaData> : IEmbedCollectionExpression
        where TMetaData : IMetaDataExpression
    {
        private readonly List<Embed> _embeds;
        internal EmbedCollectionExpression()
        {
            _embeds = new List<Embed>();
        }
        internal EmbedCollectionExpression(IEnumerable<Embed> filter)
        {
            _embeds = new List<Embed>();
            _embeds.AddRange(filter);
        }
        public static IEmbedCollectionExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new EmbedCollectionFactoryExpression<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<Embed> Embeds => _embeds.AsReadOnly();
        public override string ToString()
        {
            var filters = string.Join(",", _embeds.Select(f => f.Name));
            return filters;
        }
        public void Add(string name, Type type)
        {
            var filter = new Embed(name, type);
            _embeds.Add(filter);
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