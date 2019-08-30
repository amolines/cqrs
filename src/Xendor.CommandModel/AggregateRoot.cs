using System;
using System.Collections.Generic;
using System.Linq;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.Extensions.Reflection;
using Xendor.CommandModel.Validation;
using Xendor.EventBus;


namespace Xendor.CommandModel
{
    public abstract class AggregateRoot : AggregateMember, IAggregateRoot
    {
        private readonly Notification _notification;
        private readonly List<Event> _changes;
        protected AggregateRoot()
        {
            _changes = new List<Event>();
            _notification = new Notification();
        }
        protected AggregateRoot(Guid id)
            : base(id)
        {
            _notification = new Notification();
            _changes = new List<Event>();
        }
      
        public bool Removed { get; protected set; }
        internal IEnumerable<Event> FlushUncommittedChanges()
        {
            lock (_changes)
            {
                var changes = _changes.ToArray();
                var i = 0;
                foreach (var @event in changes)
                {
                    i++;
                    ((Event)@event).Version = Version + i;
                    ((Event)@event).TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                    ((Event)@event).AggregateId = Id;
                }
                Version = Version + changes.Length;
                _changes.Clear();
                return changes;
            }
        }
        internal void LoadFromHistory(IEnumerable<Event> history)
        {
            if (history == null || !history.Any()) return;
            foreach (var @event in history)
            {
                ApplyEvent(@event, false);
            }
            Version = history.Last().Version;

        }
        protected void ApplyChange(Event @event)
        {
            lock (_changes)
            {
                ApplyEvent(@event, true);
            }
        }
        private void ApplyEvent(Event @event, bool isNew)
        {
            var eventHandlerManager = CreateEventHandlerManager();
            eventHandlerManager.Invoke(@event);
            if (!isNew) return;
            lock (_changes)
            {
                _changes.Add(@event);
            }

        }
        protected abstract IApplyHandlerManager CreateEventHandlerManager();
        protected void AddError(Error error)
        {
            _notification.AddError(error);
        }
        protected void AddErrors(ErrorCollection errors)
        {
            _notification.AddErrors(errors);
        }

        #region IAggregateRoot
        public int Version { get; protected set; }
        public string CollectionName => GetType().GetCollectionName();
        public IEnumerable<Event> UncommittedChanges
        {
            get
            {
                lock (_changes)
                {
                    return _changes.AsReadOnly();
                }
            }
        }
        public INotification Notification => _notification;
        #endregion
    }
}