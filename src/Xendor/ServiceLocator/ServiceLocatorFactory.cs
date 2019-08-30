using Xendor.ServiceLocator.Exceptions;

namespace Xendor.ServiceLocator
{
    public static class ServiceLocatorFactory
    {
        #region Members

        private static IServiceLocatorFactory _serviceLocatorFactory;

        #endregion

        #region Public Static Methods

        public static void SetCurrent(IServiceLocatorFactory serviceLocatorFactory)
        {
            _serviceLocatorFactory = serviceLocatorFactory;
        }


        public static IServiceLocator Instance()
        {
            if (_serviceLocatorFactory == null)
                throw new ServiceLocatorFactoryNotFoundException();

            return _serviceLocatorFactory.Instance();
        }

        #endregion
    }
}