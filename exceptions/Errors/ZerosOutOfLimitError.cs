using System;

namespace Exceptions
{

    public class ZerosOutOfLimitError : Error
    {

        const string msg = "Number of zeros at the beginning of the number is out of limit";
        
        public ZerosOutOfLimitError()
        { }

        public ZerosOutOfLimitError(uint line, uint column) : this(msg, line, column)
        { }
        public ZerosOutOfLimitError(string message, uint line, uint column) : base(message, line, column)
        { }

        public ZerosOutOfLimitError( Exception innerException) : this(msg, innerException)
        { }
        public ZerosOutOfLimitError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}