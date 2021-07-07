using System;

namespace Exceptions
{
    public class IllegalVarInitializationStatementException : SyntaxException
    {
        const string msg = "Illegal variable initialization";

        public IllegalVarInitializationStatementException()
        { }

        public IllegalVarInitializationStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public IllegalVarInitializationStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public IllegalVarInitializationStatementException(Exception innerException) : this(msg, innerException)
        { }
        public IllegalVarInitializationStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}