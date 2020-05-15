using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Expressions.EmbedCollection
{
    public interface IEmbedCollectionExpression : IExpression
    {
        IEnumerable<Embed> Embeds { get; }
        void Add(string name);
        bool Any();
        bool Any(string name);
    }
}