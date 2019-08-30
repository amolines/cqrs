using System;

namespace Xendor.CommandModel.Tests.Code
{
    public class Telephone : AggregateMember
    {
        public Telephone(Guid id, string code, string number, string description)
            : base(id)
        {
            Code = code;
            Number = number;
            Description = description;
        }

        public string Code { get; }
        public string Number { get; }
        public string Description { get; }
    }
}