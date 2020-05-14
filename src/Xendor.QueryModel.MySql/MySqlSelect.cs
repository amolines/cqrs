using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.QueryProcessor.Infrastructure;

namespace Xendor.QueryModel.MySql
{
    public abstract class MySqlSelect : Query
    {
        #region Attributes
        private readonly List<string> _where;
        private string _limit;
        private string _orderBy;
        #endregion

        protected MySqlSelect()
            : base(new Dictionary<string, object>())
        {
            _where = new List<string>();
        }

        private string Where => _where.Any() ? $" WHERE {string.Join(" AND ", _where)}" : string.Empty;
        public override string Sql => $" {Select} {Joins} {Where} {_orderBy} {_limit} ";
        public override IQuery SqlCount => new CountQuery(Parameters, Joins, Where);
        private class CountQuery : Query
        {
            private readonly string _joins;
            private readonly string _where;
            public CountQuery(IDictionary<string, object> parameters, string joins, string where)
                : base(parameters)
            {
                _joins = joins;
                _where = where;
            }
            public override string Sql => $"SELECT COUNT(*) {_joins} {_where} ";
            public override void SetCriteria(ICriteria criteria)
            {
                throw new System.NotImplementedException();
            }

            public override IQuery SqlCount => throw new System.NotImplementedException();
        }
        public override void SetCriteria(ICriteria criteria)
        {
            if (criteria.IsPaginate)
            {
                var limit = new Limit(criteria.Paginate);
                limit.AddParameters(Parameters);
                _limit = limit.Sql;
            }
            else
            {
                if (criteria.IsSlice)
                {
                    var limit = new Limit(criteria.Slice);
                    limit.AddParameters(Parameters);
                    _limit = limit.Sql;
                }
            }


            if (criteria.Sort != null)
            {
                var sort = new OrderBy(criteria.Sort);
                _orderBy = sort.Sql;
            }


            if (criteria.FullTextSearch != null)
            {
                var fullTextSearch = new Match(criteria.FullTextSearch);
                fullTextSearch.AddParameters(Parameters);
                _where.Add(fullTextSearch.Sql);
            }

            if (criteria.Filters.Filters.Any())
            {
                var filters = new Where(criteria.Filters.Filters);
                filters.AddParameters(Parameters);
                _where.Add(filters.Sql);
            }
        }
        protected abstract string Select { get;  }
        protected abstract string Joins { get;  }
    }
}