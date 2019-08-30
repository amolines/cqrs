using CitiBank.View.Views.Accounts.Dtos;
using Xendor.QueryModel.Attributes;

namespace CitiBank.View.Views.Accounts.Criterias
{
    [EmbedField("operations" , typeof(OperationDto))]
    public class AccountCriteria
    {
        [Field("number")]
        public string Number { get; set; }
       
        [DeepField("product")]
        public ProductCriteria Product { get; set; }

        [DeepField("client")]
        public ClientCriteria Client { get; set; }

    }
}