namespace Xendor.QueryModel.Criteria.Paginate
{
    public interface IPaginateExpression : IExpression
    {
        int Page {  get; }
        int Limit { get; }
    }
}