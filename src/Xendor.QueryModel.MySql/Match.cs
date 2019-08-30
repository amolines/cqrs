using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.MySql
{
    internal class Match
    {
        private readonly string _match;
        private readonly string _value;
        public Match(FullTextSearch fullTextSearch)
        {

            var values = fullTextSearch.Name.Select(v=> $"`{v}`");


            _match = $"MATCH({ string.Join(",", values)}) AGAINST(@q IN BOOLEAN MODE)";
            _value = fullTextSearch.Value;
        }
        public string Sql => _match;
        public void AddParameters(IDictionary<string, object> parameters)
        {
            if(!parameters.ContainsKey("@q"))
                parameters.Add("@q" , _value);
        }
    }
}