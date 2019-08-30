namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class DoubleFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DoubleFilterConvert();
        }
    }
}