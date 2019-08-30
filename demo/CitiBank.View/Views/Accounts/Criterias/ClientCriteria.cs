using Xendor.QueryModel.Attributes;

namespace CitiBank.View.Views.Accounts.Criterias
{

    public class ClientCriteria
    {
        [Field("name", true)]
        public string Name { get; set; }
        [Field("lastName", true)]
        public string LastName { get; set; }
        [Field("email", true)]
        public string Email { get; set; }
    }
}