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
        public static bool TryGetFullTextSearch(this List<string> expression, IDictionary<string, Type> fields, out FullTextSearch fullTextSearch)
        {
            if (expression == null)
            {
                fullTextSearch = null;
                return false;
            }
            var fullTextSearchParameter = expression.FirstOrDefault(x => x.Contains("q="));
            expression.Remove(fullTextSearchParameter);
            if (fullTextSearchParameter != null)
            {
                var value = fullTextSearchParameter.Split('=')[1];
                fullTextSearch = new FullTextSearch(fields.Keys.ToList(), value);
                return true;
            }
            fullTextSearch = null;
            return false;
        }
        public static FilterCollection SetFilters(this List<string> expression, IDictionary<string, Type> fields)
        {
            var filters = new FilterCollection();
            foreach (var exp in expression)
            {
                var name = exp.Split('=')[0];
                var value = exp.Split('=')[1];
                var type = fields[name];
                filters.Add(name, value, type);
            }
            expression.Clear();
            return filters;
        }
        public static bool TryGetPaginate(this List<string> expression, out Paginate paginate)
        {
            if (expression == null)
            {
                paginate = null;
                return false;
            }
            var limitParameter = expression.FirstOrDefault(x => x.Contains("_limit="));
            var pageParameter = expression.FirstOrDefault(x => x.Contains("_page="));
            expression.Remove(limitParameter);
            expression.Remove(pageParameter);
            if (pageParameter != null)
            {
                var pageValue = Convert.ToInt32(pageParameter.Split('=')[1]);
                if (limitParameter == null)
                {
                    paginate = new Paginate(pageValue);
                }
                else
                {
                    var limitValue = Convert.ToInt32(limitParameter.Split('=')[1]);
                    paginate = new Paginate(pageValue, limitValue);
                }
               
                return true;
            }
            paginate = null;
            return false;
        }
        public static bool TryGetSlice(this List<string> expression, out Slice slice)
        {
            if (expression == null)
            {
                slice = null;
                return false;
            }
            var startParameter = expression.FirstOrDefault(x => x.Contains("_start="));
            var endParameter = expression.FirstOrDefault(x => x.Contains("_end="));
            expression.Remove(startParameter);
            expression.Remove(endParameter);
            if (startParameter != null)
            {
                var startValue = Convert.ToInt32(startParameter.Split('=')[1]);
                if (endParameter == null)
                {
                    slice = new Slice(startValue, null);
                }
                else
                {
                    var endValue = Convert.ToInt32(endParameter.Split('=')[1]);
                    slice = new Slice(startValue, endValue);
                }

                return true;
            }

            slice = null;
            return false;
        }
        public static bool TryGetSort(this List<string> expression, out Sort sort)
        {
            if (expression == null)
            {
                sort = null;
                return false;
            }
            var sortParameter = expression.FirstOrDefault(x => x.Contains("_sort="));
            var orderParameter = expression.FirstOrDefault(x => x.Contains("_order="));
            expression.Remove(sortParameter);
            expression.Remove(orderParameter);
            if (sortParameter != null && orderParameter != null)
            {
                var fields = new List<Field>();

                var sortValue = sortParameter.Split('=')[1].Split(',');
                var orderValue = orderParameter.Split('=')[1].Split(',');
                var index = 0;
                foreach (var value in sortValue)
                {
                    var field = orderValue[index].Equals("asc") ? new Field(value, Order.Asc) : new Field(value, Order.Desc);
                    index++;
                    fields.Add(field);
                }
                sort = new Sort(fields);
                return true;
            }
            sort = null;
            return false;
        }


        
        public static bool SortIsValid(this List<string> expression, IEnumerable<string> fields)
        {
            var sortParameter = expression.FirstOrDefault(x => x.Contains("_sort="));
            if (sortParameter == null) return false;
            var sortValue = sortParameter.Split('=')[1].Split(',');
            return sortValue.Intersect(fields).Count().Equals(sortValue.Count());

        }
        public static bool FilterIsValid(this List<string> expression, IEnumerable<string> fields)
        {
            var filters = new List<string>();
            foreach (var exp in expression)
            {
                var name = exp.Split('=')[0];
                filters.Add(name);
            }
            return filters.Distinct().Intersect(fields).Count().Equals(filters.Distinct().Count());

        }

    }
}