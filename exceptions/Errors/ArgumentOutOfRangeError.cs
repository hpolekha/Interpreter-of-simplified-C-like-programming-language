using System;

namespace Exceptions
{

    public class NumberOutOfRangeError : Error
    {

        const string msg = "Number is out of range";
        
        public NumberOutOfRangeError()
        { }

        public NumberOutOfRangeError(uint line, uint column) : this(msg, line, column)
        { }
        public NumberOutOfRangeError(string message, uint line, uint column) : base(message, line, column)
        { }

        public NumberOutOfRangeError( Exception innerException) : this(msg, innerException)
        { }
        public NumberOutOfRangeError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}