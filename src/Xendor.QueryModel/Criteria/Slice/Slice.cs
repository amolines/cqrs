using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Slice
{
    public class Slice :  ISlice
    {
        internal Slice(int start, int? end = null)
        {
            Start = start;
            End = end;
        }
        public static ISlice Extract(IQueryCollection queryCollection)
        {
            var factory = new SliceFactory(queryCollection);
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