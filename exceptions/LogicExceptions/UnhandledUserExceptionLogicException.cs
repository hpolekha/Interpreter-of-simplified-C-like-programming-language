using System;
namespace Exceptions
{
    public class UnhandledUserExceptionLogicException : LogicException
    {
        const string msg = "Unhandled exception";

        public UnhandledUserExceptionLogicException()
        { }

        public UnhandledUserExceptionLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UnhandledUserExceptionLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UnhandledUserExceptionLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UnhandledUserExceptionLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}