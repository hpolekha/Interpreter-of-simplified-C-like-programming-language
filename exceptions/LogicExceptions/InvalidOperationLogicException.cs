using System;

namespace Exceptions
{
    public class InvalidOperationLogicException : LogicException
    {
        const string msg = "Invalid operation";

        public InvalidOperationLogicException()
        { }

        public InvalidOperationLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public InvalidOperationLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public InvalidOperationLogicException(Exception innerException) : this(msg, innerException)
        { }
        public InvalidOperationLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}