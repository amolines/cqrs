using System;
using System.Collections.Generic;
using System.Linq;

namespace Xendor.Reflection
{
    public class TypeFinder : ITypeFinder
    {
        private readonly IAssemblyFinder _assemblyFinder;

        /// <exception cref="ArgumentNullException"><paramref name="assemblyFinder"/> is <see langword="null" />.</exception>
        public TypeFinder(IAssemblyFinder assemblyFinder)
        {
            _assemblyFinder = assemblyFinder ?? throw new ArgumentNullException(nameof(assemblyFinder));
        }

        public Type[] Find(Func<Type, bool> predicate)
        {

            return GetAllTypes().Where(predicate).ToArray();
        }

        public Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        public Type[] FindInMecalux(Func<Type, bool> predicate)
        {
            return GelAllTypesInMecalux().Where(predicate).ToArray();
        }

        public Type[] FindAllInMecalux()
        {
            return GelAllTypesInMecalux().ToArray();
        }

        public Type[] FindAll(string assemblyName, Func<Type, bool> predicate)
        {
            var assembly = _assemblyFinder.GetAssembly(assemblyName);
            var types = assembly.GetTypes().Where(predicate).ToArray();
            return types;
        }

        private List<Type> GetAllTypes()
        {
            var types = _assemblyFinder
               .GetAllAssemblies()
               .SelectMany(x => x.GetTypes());
            return types.ToList();

        }

        private IEnumerable<Type> GelAllTypesInMecalux()
        {
            var types = _assemblyFinder
                .GetAllAssemblies(a => a.FullName.StartsWith("Mecalux"))
                .SelectMany(x => x.GetTypes());
            return types;
        }
    }
}