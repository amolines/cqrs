using System;
using MassTransit;
using Xendor.ServiceLocator;

namespace Xendor.EventBus
{
    public interface IEventBus : ISingletonLifestyle
    {
        void Publish(object @event);

        void Subscribe<TConsumer>(string queueName, Func<TConsumer> consumerFactoryMethod)
            where TConsumer : class, IConsumer;

    }
}