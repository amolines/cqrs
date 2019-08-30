

namespace Xendor.Data.MySql
{
    public class MySqlConnection : UnitOfWorkConnection
    {
        [Connection("server")]
        public string Server { get; set; }
        [Connection("user id")]
        public string UserId { get; set; }
        [Connection("database")]
        public string DataBase { get; set; }
        [Connection("Pwd")]
        public string Pwd { get; set; }
        [Connection("Unicode")]
        public bool Unicode { get; set; }
        [Connection("port")]
        public int Port { get; set; }
        [Connection("license key")]
        public string LicenseKey { get; set; }
     


    }
}