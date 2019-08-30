using System;

namespace Xendor.ServiceLocator.Exceptions
{
    public class ServiceLocatorFactoryNotFoundException : Exception
    {
        public ServiceLocatorFactoryNotFoundException() : base("Service Locator Factory not found") { }
    }
}