namespace Xendor.QueryModel.Data
{
    public  class DbFactoryExpression : IFactoryExpression<ISelectQuery>
    {
        public TSelect Create<TSelect>(ICriteria criteria)
            where TSelect : ISelectQuery, new()
        {
            var select = new TSelect();
            select.SetCriteria(criteria);
            return select;
        }

    }
}