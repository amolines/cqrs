namespace Xendor.QueryModel.Expressions.Converts
{
    internal class StringFilterConvert : FilterConvert<string>
    {
        protected override string ToConvert(string value)
        {
            return value.Trim();
        }
    }
}