using System;

namespace Exceptions
{

    public class OpeningBraceExpectedException : SyntaxException
    {

        const string msg = "Opeing brace is expected";

        public OpeningBraceExpectedException()
        { }

        public OpeningBraceExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public OpeningBraceExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public OpeningBraceExpectedException(Exception innerException) : this(msg, innerException)
        { }
        public OpeningBraceExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}