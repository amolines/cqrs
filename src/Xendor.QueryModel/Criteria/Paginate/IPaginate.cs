namespace Xendor.QueryModel.Criteria.Paginate
{
    public interface IPaginate : ICriteria<NullMetaDataCriteria>
    {
        int Page {  get; }
        int Limit { get; }
    }
}