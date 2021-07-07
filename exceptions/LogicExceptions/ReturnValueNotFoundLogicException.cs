using System;

namespace Exceptions
{
    public class ReturnValueNotFoundLogicException : LogicException
    {
        const string msg = "Not all code paths return a value";

        public ReturnValueNotFoundLogicException()
        { }

        public ReturnValueNotFoundLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public ReturnValueNotFoundLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ReturnValueNotFoundLogicException(Exception innerException) : this(msg, innerException)
        { }
        public ReturnValueNotFoundLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}