using System;
using Xendor.CommandModel.Command;
using Xendor.Data;
using Xendor.MessageBroker;

namespace Xendor.CommandModel.MessageBroker
{
    public class CommandMessageFilter<TDataMapper> : ICommandMessageFilter
        where TDataMapper : IDataMapper<IEnvelope, ICommand>, new()
    {
        private readonly IDataMapper<IEnvelope, ICommand> _dataMapper;
        protected CommandMessageFilter()
        {
            Binding = new Binding();
            _dataMapper = new TDataMapper();
        }
        public Binding Binding { get; }

        public ICommand Mapper(IEnvelope data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return _dataMapper.Mapper(data);
        }
    }
}