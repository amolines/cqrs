using System;
using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing
{
    public class DeletedEvent : Event
    {
        protected DeletedEvent(DateTime date, string user)
        {
            Date = date;
            User = user;
        }

        public DateTime Date { get; }
        public string User { get; }
    }
}