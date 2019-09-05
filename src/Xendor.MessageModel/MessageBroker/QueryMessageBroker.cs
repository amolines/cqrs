using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xendor.Data;
using Xendor.MessageBroker;
using Version = System.Version;

namespace Xendor.MessageModel.MessageBroker
{
    public class QueryMessageBroker : IQueryMessageBroker
    {
        private readonly IList<IQueryMessageFilter> _filters;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly Func<IUnitOfWork,string, IVersionService> _versionServiceFactoryMethod;
        public QueryMessageBroker(IUnitOfWorkFactory unitOfWorkFactory, Func<IUnitOfWork ,string, IVersionService> versionServiceFactoryMethod)
        {
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _versionServiceFactoryMethod = versionServiceFactoryMethod ?? throw new ArgumentNullException(nameof(versionServiceFactoryMethod));
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
                    var versionService = _versionServiceFactoryMethod(unitOfWork,envelope.ContentType.Split('.')[0]);
                    await versionService.SaveAndCreate(envelope);
                    var filter = _filters.FirstOrDefault(f => f.Binding["contentType"].Value.Equals(envelope.ContentType));
                    if (filter != null)
                    {
                        var value = filter.Mapper(envelope);
                        await unitOfWork.ExecuteNonQueryAsync(value);
                    }

                    unitOfWork.Commit();

                }
                catch (Exception ex)
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