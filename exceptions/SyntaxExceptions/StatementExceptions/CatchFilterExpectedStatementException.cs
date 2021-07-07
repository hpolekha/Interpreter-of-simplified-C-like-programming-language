using System;

namespace Exceptions
{
    public class CatchFilterExpectedStatementException : SyntaxException
    {
        const string msg = "Filter is expected in the try-catch statement";

        public CatchFilterExpectedStatementException()
        { }

        public CatchFilterExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public CatchFilterExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public CatchFilterExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public CatchFilterExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}