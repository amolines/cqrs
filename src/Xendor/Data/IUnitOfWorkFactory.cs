using Xendor.ServiceLocator;

namespace Xendor.Data
{
    public interface IUnitOfWorkFactory : ISingletonLifestyle
    {
        IUnitOfWork Create();
        IUnitOfWorkConnection Connection { get; }
    }
}