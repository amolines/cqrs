using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.Paginate
{
    public class Paginate: IPaginate
    {
        internal Paginate(int page, int limitByDefault = 10)
        {
            Page = page;
            Limit = limitByDefault;
        }

        public static IPaginate Extract(IQueryCollection queryCollection)
        {
            var factory = new PaginateFactory(queryCollection);
            return factory.Create(queryCollection);
        }
        public int Page { get; }
        public int Limit { get; }
        public override string ToString()
        {
            return $"_page={Page}&_limit={Limit}";
        }

    }
}
