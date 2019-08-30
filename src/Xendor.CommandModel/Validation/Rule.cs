using System.Collections.Generic;

namespace Xendor.CommandModel.Validation
{
    public abstract class Rule<TEntity, TParameter> : RuleBase<TEntity>, IRule<TParameter>
        where TEntity : class
        where TParameter : struct
    {
        protected Rule(TEntity entity) 
            : base(entity)
        {
        }
        public ErrorCollection Validate(TParameter entity)
        {
            Clear();
            ValidateInternal(entity);
            return Errors;
        }
        protected abstract void ValidateInternal(TParameter entity);

       
    }

    public abstract class Rule<TEntity> : RuleBase<TEntity>, IRule
        where TEntity : class
    {

        protected Rule(TEntity entity)
            : base(entity)
        {
        }

        protected abstract void ValidateInternal();

        public ErrorCollection Validate()
        {
            Clear();
            ValidateInternal();
            return Errors;
        }


    }

    public class RuleBase<TEntity>
        where TEntity : class
    {
        #region Attributes

        private readonly List<Error> _brokenDomainRules;

        #endregion

        #region Constructors

        protected RuleBase(TEntity entity)
        {
            Entity = entity;
            _brokenDomainRules = new List<Error>();
        }

        #endregion

        #region Private Methods

        private void Fail(bool condition, Error error)
        {
            if (condition) AddError(error);
        }
        private bool IsNullOrBlank(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        #endregion

        #region Protected Methods

        protected void AddError(Error brokenDomainRule)
        {
            _brokenDomainRules.Add(brokenDomainRule);
        }
        protected void Clear()
        {
            _brokenDomainRules.Clear();
        }
        protected TEntity Entity { get; }
        protected ErrorCollection Errors => new ErrorCollection(_brokenDomainRules.ToArray());
        protected void FailIfNullOrBlank(string s, Error error)
        {
            Fail(IsNullOrBlank(s), error);
        }

        #endregion


    }
}