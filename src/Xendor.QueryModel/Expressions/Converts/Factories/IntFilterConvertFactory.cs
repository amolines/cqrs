namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class IntFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new IntFilterConvert();
        }
    }
}