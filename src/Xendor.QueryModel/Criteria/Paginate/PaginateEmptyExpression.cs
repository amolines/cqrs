namespace Xendor.QueryModel.Criteria.Paginate
{
    public class PaginateEmptyExpression : IPaginateExpression
    {
        public int Page => 0;
        public int Limit => 0;
    }
}