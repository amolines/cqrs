using System;
using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.Attributes;
using Xendor.QueryModel.Criteria.Paginate;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel
{
    public class PaginateQueryHeader : Header
    {
        private readonly ICriteria _criteria;
        private string _expression;
        private PaginateExpression _first;
        private PaginateExpression _prev;
        private PaginateExpression _next;
        private PaginateExpression _last;

        public PaginateQueryHeader(ICriteria criteria, long total)
        {
            Total = total;
            _criteria = criteria;
            Init();

        }
        private void Init()
        {
            var expression = new List<string>();
            if (_criteria.Filters != null && _criteria.Filters.Any())
                expression.Add(_criteria.Filters.ToString());
            if (_criteria.Sort != null)
                expression.Add(_criteria.Sort.ToString());
            if (_criteria.FullTextSearch != null)
                expression.Add(_criteria.FullTextSearch.ToString());
            _expression = $"{_criteria.Path}?{string.Join("&", expression)}";

            var totalPage = (int)Math.Ceiling((double)Total / _criteria.Paginate.Limit);

            _first = new PaginateExpression(1, _criteria.Paginate.Limit);
            _last = new PaginateExpression(totalPage, _criteria.Paginate.Limit);
            if (_criteria.Paginate.Page > 1)
            {
                _prev = new PaginateExpression(_criteria.Paginate.Page - 1, _criteria.Paginate.Limit);
            }

            if (_criteria.Paginate.Page >= totalPage) return;
            _next = new PaginateExpression(_criteria.Paginate.Page + 1, _criteria.Paginate.Limit);

        }
        [HeaderName("first")]
        public string First => $"{_criteria.Path}?{_expression}&{_first}";
        [HeaderName("prev")]
        public string Prev => _prev != null ? $"{_criteria.Path}?{_expression}&{_prev}" : string.Empty;

        [HeaderName("next")]
        public string Next => _next != null ? $"{_criteria.Path}?{_expression}&{_next}" : string.Empty;

        [HeaderName("last")]
        public string Last => $"{_criteria.Path}?{_expression}&{_last}";
        [HeaderName("X-Total-Count")]
        public long Total { get; }




    }
}