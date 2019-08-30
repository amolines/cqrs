namespace Xendor.CommandModel
{
    /// <summary>
    /// pure (isolated), is closed under entities and value objects and doesn’t depend on the external world
    /// <remarks>Note:A pure domain service doesn’t do any harm, so it’s totally fine to refer to them from your entities and value objects.</remarks>
    /// </summary>
    public interface IPureDomainService : IDomainService
    { }
}