using System;
using MassTransit;
using Xendor.Data;

namespace Xendor.EventBus.RabbitMQ
{

    public  class RabbitMqConnectionString : Connection
    {
       
        public string Password { get; set; }
        public string UserName { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string Exchange { get; set; }

        public IBusControl CreateUsingRabbitMq()
        {

                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(RabbitMqUri), hst =>
                    {
                        hst.Username(UserName);
                        hst.Password(Password);
                    });
                });
            
        }

        public IBusControl CreateUsingRabbitMq<TConsumer>(string queueName, Func<TConsumer> consumerFactoryMethod)
            where TConsumer : class, IConsumer
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqUri), hst =>
                {
                    hst.Username(UserName);
                    hst.Password(Password);
                });
                cfg.ReceiveEndpoint(host, queueName, e =>
                    e.Consumer(consumerFactoryMethod));
            });
            return bus;
        }
        public  string RabbitMqUri => $"rabbitmq://{HostName}:{Port}/{VirtualHost}/";
    }
}