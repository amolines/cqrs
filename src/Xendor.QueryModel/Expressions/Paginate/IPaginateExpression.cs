namespace Xendor.QueryModel.Expressions.Paginate
{
    public interface IPaginateExpression : IExpression
    {
        int Page {  get; }
        int Limit { get; }
    }
}