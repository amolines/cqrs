using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xendor.CommandModel.Validation
{
    public class Error
    {
        private readonly string[] _args;
        public Error(string errorCode, string message, params string[] args)
        {
            ErrorCode = errorCode;
            Message = message;
            _args = args;
        }
        public Error(string errorCode, string message, Exception cause, params string[] args)
            : this(errorCode, message, args)
        {
            Cause = cause;
        }
        public string Text => _args != null ? string.Format(Message, _args) : Message;
        public string ErrorCode { get; }
        public IEnumerable<string> Args => new ReadOnlyCollection<string>(_args);
        public string Message { get; }
        public Exception Cause { get; }
    }
}