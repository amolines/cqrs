namespace Xendor.QueryModel.Expressions
{
    public class Paginate
    {
        public Paginate(int page, int limit = 10)
        {
            Page = page;
            Limit = limit;
        }

        public int Page { get; }
        public int Limit { get; }
        public override string ToString()
        {
            return $"_page={Page}&_limit={Limit}";
        }
    }
}