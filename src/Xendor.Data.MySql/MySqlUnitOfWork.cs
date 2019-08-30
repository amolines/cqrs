using System.Data.Common;
using Devart.Data.MySql;

namespace Xendor.Data.MySql
{
    public class MySqlUnitOfWork : UnitOfWork
    {
        public MySqlUnitOfWork(IUnitOfWorkConnection connection)
            : base(connection)
        {
        }

        protected override DbProviderFactory Provider
        {
            get
            {
                var factory = new MySqlProviderFactory();
                return factory;
            }
        }
    }
}