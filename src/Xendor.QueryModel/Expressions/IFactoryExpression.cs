namespace Xendor.QueryModel.Expressions
{
    public interface IFactoryExpression<in T>
    {
        TSelect Create<TSelect>(ICriteria criteria)
                where TSelect : T, new();
    }



}