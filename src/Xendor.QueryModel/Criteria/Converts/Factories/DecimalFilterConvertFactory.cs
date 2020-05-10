namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class DecimalFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DecimalFilterConvert();
        }
    }
}