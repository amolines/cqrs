using System;
using Xendor.ServiceLocator;

namespace Xendor.Reflection
{
    
    public interface ITypeFinder : ISingletonLifestyle
    {
       
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();

       
        Type[] FindAll(string assemblyName, Func<Type, bool> predicate);


        Type[] FindInMecalux(Func<Type, bool> predicate);


        Type[] FindAllInMecalux();

    }
}