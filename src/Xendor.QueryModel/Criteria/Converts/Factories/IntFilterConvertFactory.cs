namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class IntFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new IntFilterConvert();
        }
    }
}