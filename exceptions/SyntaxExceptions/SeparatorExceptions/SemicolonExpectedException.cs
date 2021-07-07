using System;

namespace Exceptions
{

    public class SemicolonExpectedException : SyntaxException
    {

        const string msg = "Semicolon is expected";
        
        public SemicolonExpectedException()
        { }

        public SemicolonExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public SemicolonExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public SemicolonExpectedException( Exception innerException) : this(msg, innerException)
        { }
        public SemicolonExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}