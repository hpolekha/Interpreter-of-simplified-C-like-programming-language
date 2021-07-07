using System;

namespace Exceptions
{
    public class CatchKeywordExpectedStatementException : SyntaxException
    {
        const string msg = "Keyword \"catch\" is expected in the try-catch statement";

        public CatchKeywordExpectedStatementException()
        { }

        public CatchKeywordExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public CatchKeywordExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public CatchKeywordExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public CatchKeywordExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}