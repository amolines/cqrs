using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xendor.Data;
using Xendor.MessageBroker;

namespace Xendor.MessageModel.MessageBroker
{
    public class QueryMessageBroker : IQueryMessageBroker
    {
        private readonly IList<IQueryMessageFilter> _filters;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public QueryMessageBroker(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _filters = new List<IQueryMessageFilter>();
        }


        public void Bind<TFilter>() 
            where TFilter : IQueryMessageFilter, new()
        {
            var filter = new TFilter();
            _filters.Add(filter);
        }

        public async Task HandleAsync(IEnvelope envelope)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var filter = _filters.FirstOrDefault(f => f.Binding["contentType"].Value.Equals(envelope.ContentType));
                    var value = filter.Mapper(envelope);
                    await unitOfWork.ExecuteNonQueryAsync(value);
                    unitOfWork.Commit();
                }

                catch(Exception ex)
                {
                    unitOfWork.RollBack();
                }
            }
        }

        public IEnumerable<string> GetFilter()
        {
            return _filters.Select(f => f.Binding["contentType"].Value).Distinct();
        }
    }
}