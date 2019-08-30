using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.EventBus;


namespace Xendor.CommandModel.Extensions.Reflection
{
    public static class TypeExtensions
    {

        public static bool IsSnapshotable(this Type aggregateType)
        {
            if (aggregateType.GetTypeInfo().BaseType == null)
                return false;
            if (aggregateType.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType &&
                aggregateType.GetTypeInfo().BaseType.GetGenericTypeDefinition() == typeof(SnapshotAggregateRoot<>))
                return true;
            return IsSnapshotable(aggregateType.GetTypeInfo().BaseType);
        }
        public static bool IsAggregateRoot(this Type aggregateType)
        {
            if (aggregateType.GetTypeInfo().BaseType == null)
                return false;
            return aggregateType.GetTypeInfo().BaseType == typeof(AggregateRoot) || IsAggregateRoot(aggregateType.GetTypeInfo().BaseType);
        }

        public static string GetCollectionName(this Type aggregateType)
        {
            if (!IsAggregateRoot(aggregateType)) return string.Empty; //TODO: colocar error
            var collectionNameAttribute = aggregateType.GetCustomAttribute<CollectionNameAttribute>();
            return collectionNameAttribute == null ? aggregateType.Name.ToLower() : collectionNameAttribute.Name;

        }
        public static bool IsEvent(this Type eventType)
        {
            if (eventType.GetTypeInfo().BaseType == null)
                return false;
            return eventType.GetTypeInfo().BaseType == typeof(Event) || IsEvent(eventType.GetTypeInfo().BaseType);
        }
        public static bool IsSnapshot(this Type snapshotType)
        {
            if (snapshotType.GetTypeInfo().BaseType == null)
                return false;
            return snapshotType.GetTypeInfo().BaseType == typeof(Snapshot) || IsSnapshot(snapshotType.GetTypeInfo().BaseType);
        }

        public static object GetInstance(this Type type)
        {
            return GetInstance<TypeExtensions.TypeToIgnore>(type, null);
        }
        public static object GetInstance<TArg>(this Type type, TArg argument)
        {
            return GetInstance<TArg, TypeExtensions.TypeToIgnore>(type, argument, null);
        }
        public static object GetInstance<TArg1, TArg2>(this Type type, TArg1 argument1, TArg2 argument2)
        {
            return GetInstance<TArg1, TArg2, TypeExtensions.TypeToIgnore>(type, argument1, argument2, null);
        }
        public static object GetInstance<TArg1, TArg2, TArg3>(this Type type, TArg1 argument1, TArg2 argument2, TArg3 argument3)
        {
            return TypeExtensions.InstanceCreationFactory<TArg1, TArg2, TArg3>.CreateInstanceOf(type, argument1, argument2, argument3);
        }
        private class TypeToIgnore
        {
        }
        private static class InstanceCreationFactory<TArg1, TArg2, TArg3>
        {
            private static readonly Dictionary<Type, Func<TArg1, TArg2, TArg3, object>> InstanceCreationMethods =
                new Dictionary<Type, Func<TArg1, TArg2, TArg3, object>>();
            public static object CreateInstanceOf(Type type, TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                CacheInstanceCreationMethodIfRequired(type);

                return InstanceCreationMethods[type].Invoke(arg1, arg2, arg3);
            }
            private static void CacheInstanceCreationMethodIfRequired(Type type)
            {
                if (InstanceCreationMethods.ContainsKey(type))
                {
                    return;
                }

                var argumentTypes = new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) };

                Type[] constructorArgumentTypes = argumentTypes.Where(t => t != typeof(TypeExtensions.TypeToIgnore)).ToArray();

                var constructor = type.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    CallingConventions.HasThis,
                    constructorArgumentTypes,
                    new ParameterModifier[0]);

                var lamdaParameterExpressions = new[]
                {
                Expression.Parameter(typeof(TArg1), "param1"),
                Expression.Parameter(typeof(TArg2), "param2"),
                Expression.Parameter(typeof(TArg3), "param3")
            };

                var constructorParameterExpressions = lamdaParameterExpressions
                    .Take(constructorArgumentTypes.Length)
                    .ToArray();

                var constructorCallExpression = Expression.New(constructor, constructorParameterExpressions);

                var constructorCallingLambda = Expression
                    .Lambda<Func<TArg1, TArg2, TArg3, object>>(constructorCallExpression, lamdaParameterExpressions)
                    .Compile();

                InstanceCreationMethods[type] = constructorCallingLambda;
            }
        }
  

    }
}