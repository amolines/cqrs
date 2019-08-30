using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.Tests.Code
{

    public class Address
    {
        [Field("country")]
        public string Country { get; set; }
        [Field("city")]
        public string City { get; set; }
        [Field("cp")]
        public string LastName { get; set; }
    }
}