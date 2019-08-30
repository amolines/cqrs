using System;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    /// <summary>
    /// Domain services hold domain logic that doesn't naturally fit entities and value objects, participate in the decision-making process the same way entities and value objects do. Introduce domain services when you see that some logic cannot be attributed to an entity/value object because that would break their isolation.
    /// <remarks>Note:Stateless classes which can work on top of domain entities and value objects</remarks>
    /// </summary>
    public interface IDomainService : IDomainLogic, ITransientLifestyle , IDisposable
    { }
}

