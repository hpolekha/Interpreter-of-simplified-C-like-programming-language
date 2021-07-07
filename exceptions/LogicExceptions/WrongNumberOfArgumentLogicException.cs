using System;

namespace Exceptions
{
    public class WrongNumberOfArgumentLogicException : LogicException
    {
        const string msg = "Wrong number of arguments";

        public WrongNumberOfArgumentLogicException()
        { }

        public WrongNumberOfArgumentLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public WrongNumberOfArgumentLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public WrongNumberOfArgumentLogicException(Exception innerException) : this(msg, innerException)
        { }
        public WrongNumberOfArgumentLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}