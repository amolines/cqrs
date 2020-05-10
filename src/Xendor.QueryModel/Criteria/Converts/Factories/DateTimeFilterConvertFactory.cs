namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class DateTimeFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DateTimeFilterConvert();
        }
    }
}