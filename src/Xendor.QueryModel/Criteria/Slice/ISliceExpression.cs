namespace Xendor.QueryModel.Criteria.Slice
{
    public interface ISliceExpression : IExpression<NullMetaDataExpression>
    {
        int Start { get; }
        int? End { get; }
    }
}