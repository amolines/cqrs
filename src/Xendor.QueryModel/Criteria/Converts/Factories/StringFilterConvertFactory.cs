namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class StringFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new StringFilterConvert();
        }
    }
}