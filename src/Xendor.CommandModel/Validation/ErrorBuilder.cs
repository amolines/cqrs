using System;

namespace Xendor.CommandModel.Validation
{
    public class ErrorBuilder
    {
        private string _errorCode;
        private string[] _args;
        private string _message;
        private Exception _cause;
        public ErrorBuilder SetMessage(string message, params string[] args)
        {
            _message = message;
            _args = args;
            return this;
        }
        public ErrorBuilder SetErrorCode(string errorCode)
        {
            _errorCode = errorCode;
            return this;
        }
        public ErrorBuilder SetErrorCode(Exception cause)
        {
            _cause = cause;
            return this;
        }
        public Error Build()
        {
            return _cause == null ? new Error(_errorCode, _message, _cause, _args) : new Error(_errorCode,_message,_args);
        }
    }
}