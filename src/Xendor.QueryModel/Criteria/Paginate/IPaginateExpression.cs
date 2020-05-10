namespace Xendor.QueryModel.Criteria.Paginate
{
    public interface IPaginateExpression : IExpression<NullMetaDataExpression>
    {
        int Page {  get; }
        int Limit { get; }
    }
}