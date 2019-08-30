using System;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Xendor.ServiceLocator.SimpleInjector
{
    public class SimpleInjectorServiceLocatorFactory : IServiceLocatorFactory
    {
        private static readonly Lazy<IServiceLocator> SimpleInjectorResolver = new Lazy<IServiceLocator>(Created());

        private static Func<IServiceLocator> Created()
        {
            return () =>
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
                var simpleInjectorServiceLocator = new SimpleInjectorServiceLocator(container);
                container.Register<IDependencyResolver>(()=> simpleInjectorServiceLocator, Lifestyle.Singleton);
                return simpleInjectorServiceLocator;
            };
        }

        public IServiceLocator Instance()
        {
            return SimpleInjectorResolver.Value;
        }
    }
}