using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Xendor.CommandModel")]
namespace Xendor.EventBus
{
    public class Event : Message 
    {

        [InternalProperty]
        public Guid AggregateId { get; internal set; }

        [InternalProperty]
        public int Version { get; internal set; }

        [InternalProperty]
        public long TimeStamp { get; internal set; }

        

       
    }
}
