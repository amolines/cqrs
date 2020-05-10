namespace Xendor.QueryModel.Criteria.Slice
{
    public class EmptySliceExpression : ISliceExpression
    {
        public int Start => 0;
        public int? End => null;
    }
}