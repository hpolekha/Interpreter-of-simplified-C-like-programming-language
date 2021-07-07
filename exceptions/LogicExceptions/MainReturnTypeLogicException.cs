using System;

namespace Exceptions
{
    public class MainReturnTypeLogicException : LogicException
    {
        const string msg = "Entry function \"main\" must return \"int\"";

        public MainReturnTypeLogicException()
        { }

        public MainReturnTypeLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public MainReturnTypeLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public MainReturnTypeLogicException(Exception innerException) : this(msg, innerException)
        { }
        public MainReturnTypeLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}