namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class DecimalFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DecimalFilterConvert();
        }
    }
}