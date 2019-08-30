using System;


namespace Xendor.Data
{
    public abstract class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        protected UnitOfWorkFactory(IUnitOfWorkConnection unitOfWorkConnection)
        {
            Connection = unitOfWorkConnection ?? throw new ArgumentNullException(nameof(unitOfWorkConnection));
        }
        public abstract IUnitOfWork Create();
        public IUnitOfWorkConnection Connection { get; }
    }
}