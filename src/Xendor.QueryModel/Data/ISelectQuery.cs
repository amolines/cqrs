

namespace Xendor.QueryModel.Data
{
    public interface ISelectQuery : IQuery
    {
        void SetCriteria(ICriteria criteria);
        IQuery SqlCount { get; }
    }
}