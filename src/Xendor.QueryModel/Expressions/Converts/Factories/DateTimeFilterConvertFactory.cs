namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class DateTimeFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new DateTimeFilterConvert();
        }
    }
}