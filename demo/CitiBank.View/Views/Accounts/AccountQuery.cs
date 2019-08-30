using Xendor.QueryModel.MySql;

namespace CitiBank.View.Views.Accounts
{
    public class AccountQuery : MySqlSelect
    {
        private static  string _select = "SELECT AggregateId,`number`,`product.AggregateId`,`product.Name`,`client.AggregateId`,`client.Name`,`client.LastName`,`client.Email`,Id ";
        private static  string _joins = "FROM `query.account`  ";
        protected override string Select => _select;
        protected override string Joins => _joins;
    }
}