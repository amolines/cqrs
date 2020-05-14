namespace Xendor.QueryModel.QueryProcessor
{
    public interface IQueryRequest
    {
        ICriteria Criteria { get; }
    }
}