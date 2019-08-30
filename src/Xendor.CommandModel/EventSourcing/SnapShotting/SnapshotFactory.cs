using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public class SnapshotFactory : ISnapshotFactory
    {
        private readonly IDictionary<string, Type> _knownTypes;
        public SnapshotFactory(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));
            _knownTypes = new Dictionary<string, Type>();
            var types = assembly.GetSnapshotEntities();
            foreach (var type in types)
            {
                var contentTypeAttribute = type.GetCustomAttribute<ContentTypeAttribute>();
                _knownTypes.Add(contentTypeAttribute.Name, type);
            }
        }

        public IDictionary<string, Type> KnownTypes => new ReadOnlyDictionary<string, Type>(_knownTypes);
        private Type GetType(string contentType)
        {
            return _knownTypes[contentType];
        }

        public Snapshot Create(Guid id, int version, string json, string contentType)
        {
            var type = GetType(contentType);
            var snapshot = (Snapshot)Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
            snapshot.Version = version;
            snapshot.AggregateId = id;
            return snapshot;
        }
    }
}