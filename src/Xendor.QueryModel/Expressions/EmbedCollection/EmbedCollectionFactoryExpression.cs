using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.EmbedCollection
{
    internal class EmbedCollectionFactoryExpression<TMetaData> : FactoryExpression<TMetaData,
        IEmbedCollectionExpression>
        where TMetaData : IMetaDataExpression


    {
        public EmbedCollectionFactoryExpression(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return ContainsKey(EmbedCollectionReservedWords.KeyEmbed);
        }


        protected override bool Validate()
        {
            var isValid = false;
            var embeds = Cache.GetEmbedFields<TMetaData>();
            var values = GetValue(EmbedCollectionReservedWords.KeyEmbed);
            if (!values.Length.Equals(1)) return false;
            var names = values[0].Split(',');
            var count = names.Count(value => embeds.Contains(value));
            if (count.Equals(names.Length))
            {
                isValid = true;
            }
            return isValid;
        }

        protected override IEmbedCollectionExpression Extract()
        {
            var embeds = Cache.GetEmbedFields<TMetaData>();
            var embedCollection = new EmbedCollectionExpression<TMetaData>();
            var values = GetValue(EmbedCollectionReservedWords.KeyEmbed)[0];
            foreach (var value in values.Split(','))
            {
                embedCollection.Add(value);
            }
            return embedCollection;
        }
    }
}