using System;
using System.Collections.Generic;
using System.Linq;

namespace Xendor.CommandModel
{
    public class EntityCollection<TEntity> : IEntityCollection<TEntity>
        where TEntity : AggregateMember
    {
        private readonly List<TEntity> _entities;
        public EntityCollection()
        {
            _entities = new List<TEntity>();
        }
        public EntityCollection(IEnumerable<TEntity> entities)
        {
            _entities = new List<TEntity>(entities);
        }
        public virtual void Add(TEntity entity)
        {
            if (CanAdd(entity))
            {
                _entities.Add(entity);
            }
        }
        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
        public virtual bool CanAdd(TEntity entity)
        {
            return !_entities.Any(e => e.Equals(entity));
        }
        public IEnumerable<TEntity> Entities => _entities.AsReadOnly();
        public int RemoveAll(Predicate<TEntity> match)
        {
            var count = 0;

            for (var i = _entities.Count - 1; i >= 0; i--)
            {
                if (!match(_entities[i])) continue;
                ++count;
                _entities.RemoveAt(i);
            }

            return count;
        }
        public bool Exists(Predicate<TEntity> match)
        {
            return _entities.Exists(match);
        }
    }
}