
using Xendor.QueryModel.QueryProcessor.Infrastructure;

namespace Xendor.QueryModel.MySql
{
    public class MySqlConnection : IConnection
    {

        public string Server { get; set; }

        public string UserId { get; set; }

        public string DataBase { get; set; }

        public string Pwd { get; set; }

        public bool Unicode { get; set; }

        public int Port { get; set; }

        public string LicenseKey { get; set; }


        public string ConnectionString =>
            $"server={Server};user id={UserId};database={DataBase};Pwd={Pwd};Unicode={Unicode};port={Port};license key={LicenseKey}";
    }
}