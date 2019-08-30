using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel
{
    public class SliceQueryHeader : Header
    {
        public SliceQueryHeader(long total)
        {
            Total = total;
        }
        [HeaderName("X-Total-Count")]
        public long Total { get; }
    }
}