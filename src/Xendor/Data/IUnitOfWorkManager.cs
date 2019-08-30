using Xendor.ServiceLocator;

namespace Xendor.Data
{
    public interface IUnitOfWorkManager : IScopedLifestyle
    {
        IUnitOfWork CurrentUnitOfWork();

        IUnitOfWork New();
    }
}