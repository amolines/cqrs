using Xendor.QueryModel.MySql;

namespace CitiBank.View.Views.Accounts
{
    public class OperationsQuery : MySqlSelect
    {
        private static string _select = "SELECT Date, Amount, Description";
        private static string _joins = "FROM `view.operations` ";
        protected override string Select => _select;
        protected override string Joins => _joins;



    }
}