using System;
using System.Linq;
using System.Reflection;

namespace Xendor.Reflection
{
   
    public class AssemblyFinder : IAssemblyFinder
    {

        public Assembly[] GetAllAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.ToArray();
        }

        public Assembly[] GetAllAssemblies(Func<Assembly, bool> predicate)
        {
             var assemblies  = AppDomain.CurrentDomain.GetAssemblies()
                 .Where(predicate).ToArray();
            return assemblies;
        }

        public Assembly GetAssembly(string name )
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.FirstOrDefault(a => a.GetName().Name.Equals(name)) ?? Assembly.Load(name);
            return assembly;
        }
    }
}