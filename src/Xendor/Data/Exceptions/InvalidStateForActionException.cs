using System;

namespace Xendor.Data.Exceptions
{
    public class InvalidStateForActionException : Exception
    {
        public InvalidStateForActionException(UnitOfWorkState currentState, string action)
            : base($"The state [{currentState}] of UnitOfWork is not valid for action [{action}]")
        {

        }
    }
}