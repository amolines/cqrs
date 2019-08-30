using Xendor.QueryModel.Attributes;

namespace CitiBank.View.Views.Accounts.Criterias
{

    public class ProductCriteria
    {
        [Field("name" )]
        public string LastName { get; set; }
        [Field("type")]
        public int Type { get; set; }
    }
}