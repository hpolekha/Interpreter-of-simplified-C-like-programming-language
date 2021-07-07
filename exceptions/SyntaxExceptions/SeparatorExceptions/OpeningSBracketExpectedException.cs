using System;

namespace Exceptions
{

    public class OpeningSBracketExpectedException : SyntaxException
    {

        const string msg = "Opening square bracket is expected";
        
        public OpeningSBracketExpectedException()
        { }

        public OpeningSBracketExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public OpeningSBracketExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public OpeningSBracketExpectedException( Exception innerException) : this(msg, innerException)
        { }
        public OpeningSBracketExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}