using Xendor.QueryModel.MySql;

namespace CitiBank.View.Views.Accounts
{
    public class OperationsQuery : MySqlEmbedSelect
    {
        private static string _select = "SELECT Date, Amount, Description";
        private static string _joins = "FROM `view.operations` ";
        protected override string Select => _select;
        protected override string Joins => _joins;
        public override string Sql => $" {Select} {Joins} WHERE AccountId = @id ";


    }
}