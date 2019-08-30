namespace Xendor.CommandModel.Validation
{
    public interface IRuleManager<TEntity>
        where TEntity : class
    {
        ErrorCollection Validate<TDomainRule, TParameter>(TEntity entity, TParameter parameter)
            where TDomainRule : Rule<TEntity, TParameter>
            where TParameter : struct;

        ErrorCollection Validate<TDomainRule>(TEntity entity)
            where TDomainRule : Rule<TEntity>;


    }
}