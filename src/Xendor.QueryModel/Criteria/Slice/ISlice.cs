namespace Xendor.QueryModel.Criteria.Slice
{
    public interface ISlice : ICriteria<NullMetaDataCriteria>
    {
        int Start { get; }
        int? End { get; }
    }
}