using System;
using System.Threading.Tasks;
using Xendor.EventBus;

namespace Xendor.CommandModel
{
    public class DomainEventMediator : IDomainEventMediator
    {
        private readonly IDomainEventHandlerFactory _domainEventHandlerFactory;

        public DomainEventMediator(IDomainEventHandlerFactory domainEventHandlerFactory)
        {
            _domainEventHandlerFactory = domainEventHandlerFactory ?? throw new ArgumentNullException(nameof(domainEventHandlerFactory));
        }


        public async Task SendAsync(Event domainEvent)
        {
            var handlers = _domainEventHandlerFactory.CreateDomainEventHandler(domainEvent);
            foreach (var handler in handlers)
            {
                var method = handler.GetType().GetMethod("HandleAsync");
                var result = (Task)method.Invoke(handler, new object[] { domainEvent });
                await result;

              

            }
        }
    }
}
