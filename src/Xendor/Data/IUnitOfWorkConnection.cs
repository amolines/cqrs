

namespace Xendor.Data
{
    public interface IUnitOfWorkConnection : IConnection
    {
        string ConnectionString { get; }

        int RetryCount { get; set; }
    }
}
