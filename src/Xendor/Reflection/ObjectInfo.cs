using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Xendor.Reflection
{
    public class ObjectInfo : IObjectInfo
    {
        delegate object ObjectActivator(params object[] args);

        delegate T ObjectActivator<T>(params object[] args);

        public ConstructorInfo[] GetConstructors(Type type)
        {
            return type.GetConstructors();
        }
        
        public ConstructorInfo[] GetConstructors(Type type, Type[] genericTypes)
        {
            var genericType = type.MakeGenericType(genericTypes);
            return genericType.GetConstructors();
        }
        
        public ConstructorInfo GetConstructor(Type type, params Type[] args)
        {
            return type.GetConstructor(args);
        }

        public ConstructorInfo GetConstructor(Type type, Type[] genericTypes, params Type[] args)
        {
            var genericType = type.MakeGenericType(genericTypes);
            return genericType.GetConstructor(args);
        }

        #region MethodInfo

        public MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods();
        }

        public MethodInfo GetMethod(Type type, string name)
        {
            return type.GetMethod(name);
        }

        #endregion

        #region PropertyInfo

        public PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties();
        }

        public PropertyInfo GetProperty(Type type, string name)
        {
            return type.GetProperty(name);
        }

        #endregion

        public object CreateInstance(Type type, params object[] args)
        {
            var parameters = args.Select(a => a.GetType()).ToArray();
            var constructorInfo = GetConstructor(type, parameters);
            return New(constructorInfo, args);
        }

        public object CreateInstance(ConstructorInfo constructorInfo, params object[] args)
        {
            return New(constructorInfo, args);
        }

        public object CreateInstance(Type type,Type[] genericTypes, params object[] args)
        {
            var parameters = args.Select(a => a.GetType()).ToArray();
            var constructorInfo = GetConstructor(type, genericTypes,parameters);
            return New(constructorInfo, args);
        }

        public T CreateInstance<T>(params object[] args)
        {
            var parameters = args.Select(a => a.GetType()).ToArray();
            var constructorInfo = GetConstructor(typeof(T), parameters);
            return New<T>(constructorInfo, args);
        }

        public T CreateInstance<T>(ConstructorInfo constructorInfo, params object[] args)
        {
            return New<T>(constructorInfo, args);
        }

        private object New(ConstructorInfo constructorInfo, params object[] args)
        {
            var type = constructorInfo.DeclaringType;
            var paramsInfo = constructorInfo.GetParameters();

            //create a single param of type object[]
            var param =
                Expression.Parameter(typeof(object[]), "args");

            var argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(constructorInfo, argsExp);




            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda =
                Expression.Lambda(typeof(ObjectActivator), newExp, param);

            var compiled = (ObjectActivator)lambda.Compile();
            return compiled(args);
        }

        private T New<T>(ConstructorInfo constructorInfo, params object[] args)
        {
            var type = constructorInfo.DeclaringType;
            var paramsInfo = constructorInfo.GetParameters();

            //create a single param of type object[]
            var param =
                Expression.Parameter(typeof(object[]), "args");

            var argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(constructorInfo, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda =
                Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            var compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled(args);
        }


    }
}