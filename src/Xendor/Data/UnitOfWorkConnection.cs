namespace Xendor.Data
{
    public class UnitOfWorkConnection : Connection, IUnitOfWorkConnection
    {
        public string ConnectionString => ToString();

        public int RetryCount { get; set; }
    }
}