using System;

namespace Exceptions
{
    public class UndefinedFunctionCallLogicException : LogicException
    {
        const string msg = "Undefine function call";

        public UndefinedFunctionCallLogicException()
        { }

        public UndefinedFunctionCallLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UndefinedFunctionCallLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UndefinedFunctionCallLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UndefinedFunctionCallLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}