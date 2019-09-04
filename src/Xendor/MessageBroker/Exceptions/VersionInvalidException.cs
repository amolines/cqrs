using System;

namespace Xendor.MessageBroker.Exceptions
{
    public class VersionInvalidException : Exception
    {
        public VersionInvalidException(Guid aggregateId, int oldVersion , int newVersion )
            : base($"Version invalid for the aggregate [{aggregateId}-{newVersion}], the actual version is {oldVersion} ")
        {

        }
    }
}