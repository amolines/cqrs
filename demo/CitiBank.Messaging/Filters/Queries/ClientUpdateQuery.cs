using System.Collections.Generic;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class ClientUpdateQuery : Query
    {
        private readonly List<string> _set;
        public ClientUpdateQuery(IDictionary<string, object> values)
            : base(values)
        {
            _set = new List<string>();
            foreach (var value in values)
            {
                if (value.Key != "@AggregateId")
                {
                    _set.Add($"{value.Key.Replace("@", "")} = {value.Key}");
                }
                
            }
        }
        public override string Sql =>
            $"UPDATE  clients SET {string.Join(",", _set)} " +
            " WHERE AggregateId = @AggregateId ";
    }
}