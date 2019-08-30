using System;
using System.Reflection;
using Xendor.ServiceLocator;

namespace Xendor.Reflection
{

    public interface IObjectInfo : ISingletonLifestyle
    {
        ConstructorInfo[] GetConstructors(Type type);
        ConstructorInfo GetConstructor(Type type, params Type[] args);

        ConstructorInfo[] GetConstructors(Type type, Type[] genericTypes);

        ConstructorInfo GetConstructor(Type type, Type[] genericTypes, params Type[] args);

        MethodInfo[] GetMethods(Type type);

        MethodInfo GetMethod(Type type, string name);
        PropertyInfo[] GetProperties(Type type);

        PropertyInfo GetProperty(Type type, string name);

        object CreateInstance(ConstructorInfo constructorInfo, params object[] args);


        object CreateInstance(Type type, params object[] args);


        T CreateInstance<T>(ConstructorInfo constructorInfo, params object[] args);


        T CreateInstance<T>(params object[] args);


        object CreateInstance(Type type, Type[] genericTypes, params object[] args);

    }
}