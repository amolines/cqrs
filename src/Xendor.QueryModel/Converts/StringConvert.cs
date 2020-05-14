namespace Xendor.QueryModel.Converts
{
    internal class StringConvert : Convert<string>
    {
        protected override string ToConvert(string value)
        {
            return value.Trim();
        }
    }
}