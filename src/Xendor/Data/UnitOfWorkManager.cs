using System;

namespace Xendor.Data
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly object _syncLock = new object();
        private IUnitOfWork _unitOfWork;
        public UnitOfWorkManager(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        public IUnitOfWork CurrentUnitOfWork()
        {
            lock (_syncLock)
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = _unitOfWorkFactory.Create();
                }
                else
                {
                    if (!_unitOfWork.Available)
                    {
                        _unitOfWork = _unitOfWorkFactory.Create();
                    }
                }
            }
            return _unitOfWork;
        }

        public IUnitOfWork New()
        {
            return _unitOfWorkFactory.Create();
        }





    }
}