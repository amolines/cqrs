namespace Xendor.QueryModel.Expressions.Converts.Factories
{
    internal class GuidFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new GuidFilterConvert();
        }
    }
}