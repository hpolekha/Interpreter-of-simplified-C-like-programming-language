using System;

namespace Exceptions
{

    public class ClosingBraceExpectedException : SyntaxException
    {
        const string msg = "Closing brace is expected";

        public ClosingBraceExpectedException()
        { }

        public ClosingBraceExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public ClosingBraceExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }


        public ClosingBraceExpectedException(Exception innerException) : this(msg, innerException)
        { }

        public ClosingBraceExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}