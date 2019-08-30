namespace Xendor.ServiceLocator
{
    public interface IServiceLocator : IDependencyResolver, IDependencyRegister
    {
        void Verify();
    }
}