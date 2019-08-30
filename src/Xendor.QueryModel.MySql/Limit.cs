using System.Collections.Generic;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.MySql
{
    internal class Limit
    {
        private readonly int _startRecord;
        private readonly int? _maxRecords;
        public Limit(Paginate paginate)
        {
            _startRecord = (paginate.Page - 1) * paginate.Limit;
            _maxRecords = paginate.Limit;
        }
        public Limit(Slice slice)
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
