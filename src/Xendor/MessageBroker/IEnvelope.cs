using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.MessageBroker
{
    public interface IVersion
    {
        Guid AggregateId { get; }
        int Version { get; }
        string ContentType { get; }

    }

    public interface IAggregateService
    {
        int CurrentVersion(IVersion version);
        void ChangeVersion(IVersion version);
    }

    public class AggregateService : IAggregateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AggregateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public int CurrentVersion(IVersion version)
        {
            throw new NotImplementedException();
        }

        public void ChangeVersion(IVersion version)
        {
            throw new NotImplementedException();
        }
    }



    public interface IEnvelope : IVersion
    {
        long TimeStamp { get; }
         IDictionary<string, object> Payload { get; }
    }
}