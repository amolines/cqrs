using System.Collections.Generic;
using System.Linq;

namespace Xendor.CommandModel.Command
{
    public class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> _results;

        public CommandResults()
        {
            _results = new List<ICommandResult>();
        }

        public void AddResult(ICommandResult result)
        {
            _results.Add(result);
        }

        public ICommandResult[] Results => _results.ToArray();

        public bool Success
        {
            get
            {
                return _results.All(result => result.Success);
            }
        }
    }
}