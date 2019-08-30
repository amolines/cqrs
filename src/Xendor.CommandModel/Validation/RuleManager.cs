using System;
using Xendor.Reflection;

namespace Xendor.CommandModel.Validation
{
    public class RuleManager<TEntity> : IRuleManager<TEntity>
        where TEntity : class
    {
        private readonly IObjectInfo _objectInfo;
        public RuleManager(IObjectInfo objectInfo)
        {
            _objectInfo = objectInfo ?? throw new ArgumentNullException(nameof(objectInfo));
        }

        public ErrorCollection Validate<TDomainRule, TParameter>(TEntity entity, TParameter parameter) 
            where TDomainRule : Rule<TEntity, TParameter> 
            where TParameter : struct
        {
            var constructor = _objectInfo.GetConstructor(typeof(TDomainRule), typeof(TEntity));
            var domainRule =  _objectInfo.CreateInstance<TDomainRule>(constructor, entity);
            return domainRule.Validate(parameter);
        }

        public ErrorCollection Validate<TDomainRule>(TEntity entity) 
            where TDomainRule : Rule<TEntity>
        {
            var constructor = _objectInfo.GetConstructor(typeof(TDomainRule), typeof(TEntity));
            var domainRule = _objectInfo.CreateInstance<TDomainRule>(constructor, entity);
            return domainRule.Validate();
        }
    }
}