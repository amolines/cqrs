using System;
using System.Collections.Generic;
using MassTransit;
using Newtonsoft.Json;
using Xendor.Data;

namespace Xendor.EventBus.RabbitMQ
{

    //public class EventJsonConverter : JsonConverter<Dictionary<string,object>>
    //{
    //    public override void WriteJson(JsonWriter writer, Dictionary<string, object> value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Dictionary<string, object> ReadJson(JsonReader reader, Type objectType, Dictionary<string, object> existingValue, bool hasExistingValue,
    //        JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

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
                //cfg.ConfigureJsonDeserializer(settings =>
                //{
                //    settings.Converters.Add(new EventJsonConverter());
                //    return settings;
                //});
                cfg.ReceiveEndpoint(host, queueName, e =>
                    e.Consumer(consumerFactoryMethod));
            });
            return bus;
        }
        public  string RabbitMqUri => $"rabbitmq://{HostName}:{Port}/{VirtualHost}/";
    }
}