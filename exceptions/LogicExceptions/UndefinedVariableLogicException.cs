using System;

namespace Exceptions
{
    public class UndefinedVariableLogicException : LogicException
    {
        const string msg = "Udefined operator";

        public UndefinedVariableLogicException()
        { }

        public UndefinedVariableLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UndefinedVariableLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UndefinedVariableLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UndefinedVariableLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}