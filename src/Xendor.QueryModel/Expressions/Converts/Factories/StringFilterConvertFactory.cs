namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class StringFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new StringFilterConvert();
        }
    }
}