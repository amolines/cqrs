namespace Xendor.CommandModel.Command
{
    public class ValidationResult
    {
        public ValidationResult(string memberName, string message)
        {
            MemberName = memberName;
            Message = message;
        }
        public ValidationResult(string message)
        {
            Message = message;
        }
        public string MemberName { get;  }
        public string Message { get; }
    }
}