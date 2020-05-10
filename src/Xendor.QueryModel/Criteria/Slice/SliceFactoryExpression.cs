using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Slice
{
    internal class SliceFactoryExpression : FactoryExpression<NullMetaDataExpression,ISliceExpression,SliceEmptyExpression>

    {
        public SliceFactoryExpression(IQueryCollection queryCollection) 
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return ContainsKey(SliceReservedWords.KeyStart);
        }

        protected override bool Validate()
        {

            if (!TryParseValue<int>(SliceReservedWords.KeyStart, int.TryParse, out var startValue)) return false;
            if (startValue < 1) return false;
            if (TryParseValue<int>(SliceReservedWords.KeyEnd, int.TryParse, out var endValue))
            {
                if (endValue > startValue)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        protected override ISliceExpression Extract()
        {
            var start = ParseValue(SliceReservedWords.KeyStart, int.Parse);
            if (!ContainsKey(SliceReservedWords.KeyEnd)) return new SliceExpression(start);
            var end = ParseValue(SliceReservedWords.KeyEnd, int.Parse);
            return new SliceExpression(start, end);

        }
    }
}