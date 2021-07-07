using System;

namespace Exceptions
{
    public class InvalidStatementStatementException : SyntaxException
    {
        const string msg = "Statement is invalid";

        public InvalidStatementStatementException()
        { }

        public InvalidStatementStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public InvalidStatementStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public InvalidStatementStatementException(Exception innerException) : this(msg, innerException)
        { }
        public InvalidStatementStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}