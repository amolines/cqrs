using System;
using System.Collections.Generic;

namespace Xendor.CommandModel
{
    public interface IEntityCollection<TEntity> 
        where TEntity : AggregateMember
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        bool CanAdd(TEntity entity);
        IEnumerable<TEntity> Entities { get; }
        int RemoveAll(Predicate<TEntity> match);
        bool Exists(Predicate<TEntity> match);
    }

}