using System;
using System.Threading.Tasks;
using MassTransit;
using Xendor.MessageBroker;

namespace Xendor.EventBus
{
    public class EventConsumer<TEvent> : IConsumer<TEvent>
        where TEvent : Event
    {
        private readonly IMessageBroker _messageBroker;
        protected EventConsumer(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker ?? throw new ArgumentNullException(nameof(messageBroker));
        }
        private async Task ProcessEvent(IEnvelope envelope)
        {
            await _messageBroker.HandleAsync(envelope);
        }
        public async Task Consume(ConsumeContext<TEvent> context)
        {
            var envelop = new Envelope(context.Message.AggregateId, context.Message.Version, context.Message.TimeStamp, context.Message.Payload, context.Message.ContentType);
            await ProcessEvent(envelop);
        }
    }
}