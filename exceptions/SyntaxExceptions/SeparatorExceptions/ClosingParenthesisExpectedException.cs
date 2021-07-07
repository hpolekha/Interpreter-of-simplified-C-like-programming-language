using System;
namespace Exceptions
{

    public class ClosingParenthesisExpectedException : SyntaxException
    {
        const string msg = "Closing parenthesis is expected";

        public ClosingParenthesisExpectedException()
        { }

        public ClosingParenthesisExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public ClosingParenthesisExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ClosingParenthesisExpectedException(Exception innerException) : this(msg, innerException)
        { }
        public ClosingParenthesisExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}