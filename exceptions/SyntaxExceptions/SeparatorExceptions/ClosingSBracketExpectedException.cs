using System;

namespace Exceptions
{

    public class ClosingSBracketExpectedException : SyntaxException
    {
        const string msg = "Closing square bracket is expected";

        public ClosingSBracketExpectedException()
        { }

        public ClosingSBracketExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public ClosingSBracketExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }


        public ClosingSBracketExpectedException(Exception innerException) : this(msg, innerException)
        { }

        public ClosingSBracketExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}