using System.Collections.Generic;
using Xendor.QueryModel.Criteria.Paginate;
using Xendor.QueryModel.Criteria.Slice;

namespace Xendor.QueryModel.MySql
{
    internal class Limit
    {
        private readonly int _startRecord;
        private readonly int? _maxRecords;
        public Limit(IPaginateExpression paginate)
        {
            _startRecord = (paginate.Page - 1) * paginate.Limit;
            _maxRecords = paginate.Limit;
        }
        public Limit(ISliceExpression slice)
        {
            _startRecord = slice.Start - 1;
            _maxRecords = slice.End;
        }
        public string Sql => _maxRecords.HasValue ? $" LIMIT @startRecord , @maxRecords " : $" LIMIT @startRecord ";
        public void AddParameters(IDictionary<string, object> parameters)
        {
            if (!parameters.ContainsKey("@startRecord"))
                parameters.Add("@startRecord", _startRecord);
            if (_maxRecords.HasValue && !parameters.ContainsKey("@maxRecords"))
            {
                parameters.Add("@maxRecords", _maxRecords);
            }

        }
    }
}
