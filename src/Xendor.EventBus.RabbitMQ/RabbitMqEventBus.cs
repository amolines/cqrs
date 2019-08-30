using System;
using MassTransit;

namespace Xendor.EventBus.RabbitMQ
{
    

    public class RabbitMqEventBus : IEventBus
    {
        private readonly RabbitMqConnectionString _rabbitMqConnection;

        public RabbitMqEventBus(RabbitMqConnectionString rabbitMqConnection)
        {
            _rabbitMqConnection = rabbitMqConnection ?? throw new ArgumentNullException(nameof(rabbitMqConnection));
        }

        public async void Publish(object @event)
        {
            var endPoint = _rabbitMqConnection.CreateUsingRabbitMq();
            await endPoint.Publish(@event);
        }

        public void Subscribe<TConsumer>(string queueName, Func<TConsumer> consumerFactoryMethod)
            where TConsumer : class, IConsumer
        {
           var consumer =  _rabbitMqConnection.CreateUsingRabbitMq(queueName, consumerFactoryMethod);
           consumer.Start();
        }
    


    }
}
