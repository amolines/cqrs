using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xendor.CommandModel.Command;
using Xendor.MessageBroker;

namespace Xendor.CommandModel.MessageBroker
{
    public class CommandMessageBroker : ICommandMessageBroker
    {
        private readonly IList<ICommandMessageFilter> _filters;
        private readonly ICommandBus _commandBus;
        public CommandMessageBroker(ICommandBus commandBus)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
            _filters = new List<ICommandMessageFilter>();
        }


        public void Bind<TFilter>()
            where TFilter : ICommandMessageFilter, new()
        {
            var filter = new TFilter();
            _filters.Add(filter);
        }

        public async Task HandleAsync(IEnvelope envelope)
        {
            var filter = _filters.FirstOrDefault(f => f.Binding["contentType"].Value.Equals(envelope.ContentType));
            var value = filter.Mapper(envelope);
            await _commandBus.Submit(value);
        }

        public IEnumerable<string> GetFilter()
        {
            return _filters.Select(f => f.Binding["contentType"].Value).Distinct();
        }
    }
}