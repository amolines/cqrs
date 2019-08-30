namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class LongFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new LongFilterConvert();
        }
    }
}