using System;

namespace Exceptions
{

    public class UnknownSymbolError : Error
    {

        const string msg = "Unknown symbol";
        
        public UnknownSymbolError()
        { }

        public UnknownSymbolError(uint line, uint column) : this(msg, line, column)
        { }
        public UnknownSymbolError(string message, uint line, uint column) : base(message, line, column)
        { }

        public UnknownSymbolError( Exception innerException) : this(msg, innerException)
        { }
        public UnknownSymbolError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}