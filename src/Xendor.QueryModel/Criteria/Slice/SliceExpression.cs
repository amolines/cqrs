using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Slice
{
    public class SliceExpression :  ISliceExpression
    {
        internal SliceExpression(int start, int? end = null)
        {
            Start = start;
            End = end;
        }
        public static ISliceExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new SliceFactoryExpression(queryCollection);
            return factory.Create(queryCollection);
        }

        public int Start { get; }
        public int? End { get; }

        public override string ToString()
        {
            return End.HasValue ? $"_start={Start}&_end={End}" : $"_start={ Start}";
        }
    }
}