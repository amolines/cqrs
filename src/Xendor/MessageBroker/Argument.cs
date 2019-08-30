namespace Xendor.MessageBroker
{
    public class Argument
    {
        public Argument(string name, string value, ArgumentType argumentType)
        {
            Name = name;
            Value = value;
            ArgumentType = argumentType;
        }
        public string Name { get; }
        public string Value { get; }
        public ArgumentType ArgumentType { get; }
    }
}