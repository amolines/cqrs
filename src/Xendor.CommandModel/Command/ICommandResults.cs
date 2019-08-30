
namespace Xendor.CommandModel.Command
{
    public interface ICommandResults
    {
       
        ICommandResult[] Results { get; }

        bool Success { get; }
    }
}