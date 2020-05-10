namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class DoubleFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DoubleFilterConvert();
        }
    }
}