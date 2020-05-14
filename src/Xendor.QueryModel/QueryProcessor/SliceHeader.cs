using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.QueryProcessor
{
    public class SliceHeader : Header
    {
        public SliceHeader(long total)
        {
            Total = total;
        }
        [HeaderName("X-Total-Count")]
        public long Total { get; }
    }
}