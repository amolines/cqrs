using System;
using System.Reflection;
using Xendor.ServiceLocator;

namespace Xendor.Reflection
{

    public interface IAssemblyFinder : ISingletonLifestyle
    {

        Assembly[] GetAllAssemblies();


        Assembly GetAssembly(string name);



        Assembly[] GetAllAssemblies(Func<Assembly, bool> predicate);
    }
}