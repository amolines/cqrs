

namespace Xendor.Data.MySql
{
    public class MySqlUnitOfWorkFactory : UnitOfWorkFactory
    {
        
        public MySqlUnitOfWorkFactory(IUnitOfWorkConnection connection) 
            : base(connection)
        {
           
        }

        public override IUnitOfWork Create()
        {
            return new MySqlUnitOfWork(Connection);
        }
    }
}