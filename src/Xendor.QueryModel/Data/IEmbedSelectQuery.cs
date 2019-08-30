using Xendor.Data;

namespace Xendor.QueryModel.Data
{
    public interface IEmbedSelectQuery : IQuery
    {
        void SetId(long id);
    }
}