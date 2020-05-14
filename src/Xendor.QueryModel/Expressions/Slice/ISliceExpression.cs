namespace Xendor.QueryModel.Expressions.Slice
{
    public interface ISliceExpression : IExpression
    {
        int Start { get; }
        int? End { get; }
    }
}