namespace Xendor.QueryModel.Expressions
{
    public class Slice
    {
        public Slice(int start, int? end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; }
        public int? End { get; }

        public override string ToString()
        {
            return End.HasValue ?  $"_start={Start}&_end={End}" : $"_start={ Start}";
        }
    }
}