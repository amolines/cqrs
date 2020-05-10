namespace Xendor.QueryModel.Criteria.Slice
{
    public interface ISliceExpression : IExpression
    {
        int Start { get; }
        int? End { get; }
    }
}