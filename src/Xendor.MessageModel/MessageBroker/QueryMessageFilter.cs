using System;
using Xendor.Data;
using Xendor.MessageBroker;

namespace Xendor.MessageModel.MessageBroker
{
    public class QueryMessageFilter<TDataMapper> : IQueryMessageFilter
        where TDataMapper : IDataMapper<IEnvelope, IQuery>, new()
    {
        private readonly IDataMapper<IEnvelope, IQuery> _dataMapper;
        protected QueryMessageFilter()
        {
            Binding = new Binding();
            _dataMapper = new TDataMapper();
        }
        public Binding Binding { get; }

        public IQuery Mapper(IEnvelope data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return _dataMapper.Mapper(data);
        }
    }
}