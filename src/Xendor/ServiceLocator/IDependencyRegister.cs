using System;

namespace Xendor.ServiceLocator
{
    public interface IDependencyRegister 
    {
        void Register<TService>(TService service)
            where TService : class;

        void Register<TService>()
            where TService : class;

        void Register<TContract, TService>()
            where TContract : class
            where TService : class, TContract;

        void Register(Type contract, Type service);


        void Register<TContract>(params Type[] services)
            where TContract : class;

    }
}