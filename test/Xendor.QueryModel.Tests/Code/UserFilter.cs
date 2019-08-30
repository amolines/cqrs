using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.Tests.Code
{

    public class UserFilter 
    {
        [Field("name", true)]
        public string Name { get; set; }
        [Field("lastName", true )]
        public string LastName { get; set; }
        [Field("dni")]
        public string Dni { get; set; }
        [DeepField("address")]
        public Address Address { get; set; }
    }
}