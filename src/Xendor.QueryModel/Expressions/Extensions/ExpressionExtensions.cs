using System;
using System.Collections.Generic;
using System.Linq;

namespace Xendor.QueryModel.Expressions.Extensions
{
    internal static class ExpressionExtensions
    {
        public static EmbedCollection SetEmbeds(this List<string> expression, IDictionary<string, Type> embeds)
        {
            var embedCollection = new EmbedCollection();
            var embedParameter = expression.FirstOrDefault(x => x.Contains("_embed="));
            expression.Remove(embedParameter);

            if (embedParameter == null) return embedCollection;
            var values = embedParameter.Split('=')[1];
            foreach (var value in values.Split(','))
            {
                if (embeds.ContainsKey(value))
                {
                    
                    embedCollection.Add(value, embeds[value]);
                }
                
            }
            return embedCollection;
        }
       
      
      
       
       

        
       

    }
}