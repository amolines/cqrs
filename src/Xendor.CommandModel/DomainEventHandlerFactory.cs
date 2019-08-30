using System;
using System.Collections;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    public class DomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        private readonly IDependencyResolver _dependencyResolver;

        public DomainEventHandlerFactory(IDependencyResolver serviceProvider)
        {
            _dependencyResolver = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public IEnumerable CreateDomainEventHandler(Event domainEvent)
        {
            var type = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = (IEnumerable)_dependencyResolver.GetServices(type);
            return handlers;
        }
    }
}