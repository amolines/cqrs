using System.Collections.Generic;

namespace Xendor.CommandModel.Tests.Code
{
    public class Phone : ValueObject
    {
        private Phone(string code, string number)
        {
            Code = code;
            Number = number;
        }
        public string Code { get; }
        public string Number { get; }
        public static Phone New(string code, string number)
        {
            return new Phone(code, number);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>()
            {
                Code,
                Number
            };
        }
    }
}