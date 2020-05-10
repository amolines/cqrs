using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Paginate
{
    internal class PaginateFactory : FactoryCriteria<NullMetaDataCriteria, IPaginate, PaginateEmpty>

    {
        public PaginateFactory(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return ContainsKey(PaginateReservedWords.KeyPage);
        }

        protected override bool Validate()
        {
            if (!TryParseValue<int>(PaginateReservedWords.KeyPage, int.TryParse, out var pageValue)) return false;
            if (pageValue < 1) return false;
            if (TryParseValue<int>(PaginateReservedWords.KeyLimit, int.TryParse, out var limitValue))
            {
                if (limitValue > 0)
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

        protected override IPaginate Extract()
        {
            var page = ParseValue(PaginateReservedWords.KeyPage, int.Parse);
            if (!ContainsKey(PaginateReservedWords.KeyLimit)) return new Paginate(page);
            var limit = ParseValue(PaginateReservedWords.KeyLimit, int.Parse);
            return new Paginate(page, limit);
        }
    }
}