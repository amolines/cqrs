namespace Xendor.QueryModel.Criteria.Paginate
{
    public class PaginateEmpty : IPaginate
    {
        public int Page => 0;
        public int Limit => 0;
    }
}