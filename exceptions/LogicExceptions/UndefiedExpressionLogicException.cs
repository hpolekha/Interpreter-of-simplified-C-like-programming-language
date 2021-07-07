using System;

namespace Exceptions
{
    public class UndefinedExpressionLogicException : LogicException
    {
        const string msg = "Unexpected expression";

        public UndefinedExpressionLogicException()
        { }

        public UndefinedExpressionLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UndefinedExpressionLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UndefinedExpressionLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UndefinedExpressionLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}