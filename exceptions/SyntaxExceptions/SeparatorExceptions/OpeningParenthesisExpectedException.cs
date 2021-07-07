using System;

namespace Exceptions
{

    public class OpeningParenthesisExpectedException : SyntaxException
    {

        const string msg = "Opening parenthesis is expected";
        
        public OpeningParenthesisExpectedException()
        { }

        public OpeningParenthesisExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public OpeningParenthesisExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public OpeningParenthesisExpectedException( Exception innerException) : this(msg, innerException)
        { }
        public OpeningParenthesisExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}