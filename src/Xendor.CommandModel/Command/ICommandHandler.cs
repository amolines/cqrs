using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Command
{
    /// <summary>
    /// Business logic is attributed to the domain model, while interactions with the external world – to the application service.
    /// As well as cross-aggregate validation SERVICES should handle any process specific validation.
    /// <para>
    /// You can notice a pattern in most code bases that adhere to such a guideline. Their execution flow goes as follows:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>Prepare all information needed for a business operation: load participating entities from the database and retrieve any required data from other external sources.</description>
    /// </item>
    /// <item>
    /// <description>
    /// Execute the operation. The operation consists of one or more business decisions made by the domain model. Those decisions result in either changing the model’s state, generating some artifacts, or both.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Apply the results of the operation to the outside world.
    /// </description>
    /// </item>
    /// </list>
    /// <remarks>Note:Stateless classes which can work on top of domain entities and value objects</remarks>
    /// </summary>
    public interface ICommandHandler<in TCommand> : ITransientLifestyle 
        where TCommand : ICommand
    {
        Task<ICommandResult> Handle(TCommand command);
    }
}