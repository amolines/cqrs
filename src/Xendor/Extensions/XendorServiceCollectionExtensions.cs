using Xendor.Reflection;
using Xendor.ServiceLocator;

namespace Xendor.Extensions
{
    public static class XendorServiceCollectionExtensions
    {

        public static void AddXendor(this IServiceLocator services)
        {
            //services.Register(typeof(ILogger<>), typeof(Logger<>));
            services.Register<IAssemblyFinder, AssemblyFinder>();
            services.Register<ITypeFinder, TypeFinder>();
            services.Register<IObjectInfo, ObjectInfo>();
            services.Register<IAttributeFinder, AttributeFinder>();
        }
        
    }
}