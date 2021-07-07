using System;

namespace Exceptions
{

    public class InvalidOperatorError : Error
    {

        const string msg = "Invalid operator";
        
        public InvalidOperatorError()
        { }

        public InvalidOperatorError(uint line, uint column) : this(msg, line, column)
        { }
        public InvalidOperatorError(string message, uint line, uint column) : base(message, line, column)
        { }

        public InvalidOperatorError( Exception innerException) : this(msg, innerException)
        { }
        public InvalidOperatorError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}