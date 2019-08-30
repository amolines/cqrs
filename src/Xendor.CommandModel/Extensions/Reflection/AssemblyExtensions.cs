using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.CommandModel.Extensions.Reflection
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetSnapshotAggregateRootEntities(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsSnapshotable()).ToArray();
        }
        public static IEnumerable<Type> GetAggregateRootEntities(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsAggregateRoot()).ToArray();
        }
        public static IEnumerable<Type> GetEventEntities(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsEvent()).ToArray();
        }
      public static IEnumerable<Type> GetSnapshotEntities(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsSnapshot()).ToArray();
        }
    }
}