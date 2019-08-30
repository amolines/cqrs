using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xendor.CommandModel.Extensions.Reflection;
using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing
{
    public class EventFactory : IEventFactory
    {
        private readonly IDictionary<string, Type> _knownTypes;
        public EventFactory(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));
            _knownTypes = new Dictionary<string, Type>();
            var types = assembly.GetEventEntities();
            foreach (var type in types)
            {
                var contentTypeAttribute = type.GetCustomAttribute<ContentTypeAttribute>();
                if(contentTypeAttribute != null)
                 _knownTypes.Add(contentTypeAttribute.Name, type);
            }
        }

        public IDictionary<string, Type> KnownTypes => new ReadOnlyDictionary<string, Type>(_knownTypes);
        private Type GetType(string contentType)
        {
            return _knownTypes[contentType];
        }

        public Event Create(Guid id, int version, long timeStamp,string json, string contentType)
        {
            var type = GetType(contentType);
            var @event = (Event)Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
            @event.Version = version;
            @event.TimeStamp = timeStamp;
            @event.AggregateId = id;
            return @event;
        }
    }
}