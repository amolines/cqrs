namespace Xendor.CommandModel.Validation
{

    public interface IRule<in TParameter>
        where TParameter : struct
    {
        ErrorCollection Validate(TParameter entity);
    }

    public interface IRule
    {
        ErrorCollection Validate();
    }

}