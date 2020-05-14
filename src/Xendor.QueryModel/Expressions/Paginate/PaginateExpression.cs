using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.Paginate
{
    public class PaginateExpression: IPaginateExpression
    {
        public  PaginateExpression(int page, int limitByDefault = 10)
        {
            Page = page;
            Limit = limitByDefault;
        }

        public static IPaginateExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new PaginateFactoryExpression(queryCollection);
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
