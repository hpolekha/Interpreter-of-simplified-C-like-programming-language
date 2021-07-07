
using System;

namespace Exceptions
{
    public class UndefinedOperatorLogicException : LogicException
    {
        const string msg = "Undefine operator";

        public UndefinedOperatorLogicException()
        { }

        public UndefinedOperatorLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UndefinedOperatorLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UndefinedOperatorLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UndefinedOperatorLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}