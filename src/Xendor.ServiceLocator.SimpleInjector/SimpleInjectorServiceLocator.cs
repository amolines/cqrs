using System;
using System.Collections.Generic;
using SimpleInjector;
using Xendor.Extensions.Reflection;

namespace Xendor.ServiceLocator.SimpleInjector
{
    public class SimpleInjectorServiceLocator : IServiceLocator
    {
        public SimpleInjectorServiceLocator(Container container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }
        public  Container Container { get; }
        #region IServiceLocator
        public TService GetService<TService>()
            where TService : class
        {
            return Container.GetInstance<TService>();
        }
        public object GetService(Type contractType)
        {
            return Container.GetInstance(contractType);
        }
        public IEnumerable<object> GetServices(Type contractType)
        {
            return Container.GetAllInstances(contractType);
        }
        public void Register<TService>(TService service)
            where TService : class
        {
            Container.Register<TService>(() => service, Lifestyle.Singleton);
        }
        public void Register<TService>() 
            where TService : class
        {
            var service = typeof(TService);
            if (service.IsAssignableFrom<ITransientLifestyle>())
            {
                Container.Register<TService>(Lifestyle.Transient);
            }
            else
            {
                Container.Register<TService>(service.IsAssignableFrom<IScopedLifestyle>() ? Lifestyle.Scoped : Lifestyle.Singleton);
            }
        }

        public void Register<TContract, TService>(Func<TService> instanceCreator) 
            where TContract : class 
            where TService : class, TContract
        {
            var service = typeof(TService);
            if (service.IsAssignableFrom<ITransientLifestyle>())
            {
                Container.Register(instanceCreator, Lifestyle.Transient);
            }
            else
            {
                Container.Register(instanceCreator , service.IsAssignableFrom<IScopedLifestyle>() ? Lifestyle.Scoped : Lifestyle.Singleton);
            }
           
        }

        public void RegisterTransient<TContract, TService>() 
            where TContract : class
            where TService : class, TContract
        {
            var contract = typeof(TContract);
            var service = typeof(TService);
            Container.Register(contract, service, Lifestyle.Transient);
        }

        public void RegisterScoped<TContract, TService>() 
            where TContract : class
            where TService : class, TContract
        {
            var contract = typeof(TContract);
            var service = typeof(TService);
            Container.Register(contract, service, Lifestyle.Scoped);
        }

        public void RegisterSingleton<TContract, TService>()
            where TContract : class 
            where TService : class, TContract
        {
            var contract = typeof(TContract);
            var service = typeof(TService);
            Container.Register(contract, service, Lifestyle.Singleton);

        }

        public void Register<TContract, TService>()
            where TContract : class 
            where TService : class, TContract
        {
            var contract = typeof(TContract);
            var service = typeof(TService);
            Register(contract,service);
        }
        public void Register(Type contract, Type service)
        {
            if (contract.IsAssignableFrom<ITransientLifestyle>())
            {
                Container.Register(contract, service, Lifestyle.Transient);
            }
            else
            {
                Container.Register(contract, service,
                    contract.IsAssignableFrom<IScopedLifestyle>() ? Lifestyle.Scoped : Lifestyle.Singleton);
            }
        }

        public void Register<TContract>(params Type[] services) 
            where TContract : class
        {
          Container.Collection.Register<TContract>(services);
        }

        public void Verify()
        {
            Container.Verify();
        }
        #endregion
    }
}
