using System;

namespace Exceptions
{
    public class CatchFilterUnknownStatementException : SyntaxException
    {
        const string msg = "Filter is unknown in the try-catch statement";

        public CatchFilterUnknownStatementException()
        { }

        public CatchFilterUnknownStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public CatchFilterUnknownStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public CatchFilterUnknownStatementException(Exception innerException) : this(msg, innerException)
        { }
        public CatchFilterUnknownStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}