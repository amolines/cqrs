namespace Xendor.QueryModel.Criteria.Slice
{
    public class SliceEmptyExpression : ISliceExpression
    {
        public int Start => 0;
        public int? End => null;
    }
}