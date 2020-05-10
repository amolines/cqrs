using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Paginate
{
    internal class PaginateFactoryExpression : FactoryExpression<NullMetaDataExpression, IPaginateExpression, PaginateEmptyExpression>

    {
        public PaginateFactoryExpression(IQueryCollection queryCollection)
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

        protected override IPaginateExpression Extract()
        {
            var page = ParseValue(PaginateReservedWords.KeyPage, int.Parse);
            if (!ContainsKey(PaginateReservedWords.KeyLimit)) return new PaginateExpression(page);
            var limit = ParseValue(PaginateReservedWords.KeyLimit, int.Parse);
            return new PaginateExpression(page, limit);
        }
    }
}