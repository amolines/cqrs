namespace Xendor.CommandModel
{
    /// <summary>
    /// impure (non-isolated), injection of an impure domain service into entities breaks the isolation, so I’d recommend against it.
    /// </summary>
    public interface IImpureDomainService : IDomainService
    { }
}