namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class LongFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new LongFilterConvert();
        }
    }
}