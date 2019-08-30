using System;
using System.Collections.Generic;

namespace Xendor.ServiceLocator
{
    public interface IDependencyResolver : ISingletonLifestyle
    {
        TService GetService<TService>()
            where TService : class;

        object GetService(Type contractType);

        IEnumerable<object> GetServices(Type contractType);
    }
}
