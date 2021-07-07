using System;

namespace Exceptions
{
    public class DvivisionByZeroLogicException : LogicException
    {
        const string msg = "Division by zero";

        public DvivisionByZeroLogicException()
        { }

        public DvivisionByZeroLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public DvivisionByZeroLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public DvivisionByZeroLogicException(Exception innerException) : this(msg, innerException)
        { }
        public DvivisionByZeroLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}