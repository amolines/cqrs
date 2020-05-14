using Xendor.QueryModel.Attributes;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.Tests.Code
{

    public class UserFilter : IMetaDataExpression
    {
        [Field("id")]
        public int Id { get; set; }
        [Field("name", true)]
        public string Name { get; set; }
        [Field("lastName", true )]
        public string LastName { get; set; }
        [Field("dni")]
        public string Dni { get; set; }
        [DeepField("address")]
        public Address Address { get; set; }
    }

    public class UserMetaDataCriteria : IMetaDataExpression
    {
        [Field("id", false)]
        public int Id { get; set; }
        [Field("name", true)]
        public string Name { get; set; }
        [Field("lastName", true)]
        public string LastName { get; set; }
        [Field("dni")]
        public string Dni { get; set; }
        [DeepField("address")]
        public Address Address { get; set; }
    }
}