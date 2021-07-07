using System;

namespace Exceptions
{
    public class ThrowExpressionExpectedStatementException : SyntaxException
    {
        const string msg = "Throw expression is expected in the statement";

        public ThrowExpressionExpectedStatementException()
        { }

        public ThrowExpressionExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public ThrowExpressionExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ThrowExpressionExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public ThrowExpressionExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}