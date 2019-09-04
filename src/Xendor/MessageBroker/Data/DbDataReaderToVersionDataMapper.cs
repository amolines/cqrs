using System.Data.Common;
using Xendor.Data;

namespace Xendor.MessageBroker.Data
{
    public class DbDataReaderToVersionDataMapper : IDataMapper<DbDataReader, IVersion>
    {
        public IVersion Mapper(DbDataReader source)
        {
            IVersion version = null;
            while (source.Read())
            {
                var id = source.GetGuid(0);
                var number = source.GetInt16(1);
                version = new Version(id, number);
            }
            return version;
        }
    }
}