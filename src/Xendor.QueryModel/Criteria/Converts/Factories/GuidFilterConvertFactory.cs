

namespace Xendor.QueryModel.Criteria.Converts.Factories
{
    internal class GuidFilterConvertFactory : IFilterConvertFactory
    {
        public IFilterConvert Create()
        {
            return new GuidFilterConvert();
        }
    }
}