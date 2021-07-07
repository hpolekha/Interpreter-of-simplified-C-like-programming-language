using System;

namespace Exceptions
{
    public class ReturnExpressionExpectedStatementException : SyntaxException
    {
        const string msg = "Return expression is expected in the statement";

        public ReturnExpressionExpectedStatementException()
        { }

        public ReturnExpressionExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public ReturnExpressionExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ReturnExpressionExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public ReturnExpressionExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}