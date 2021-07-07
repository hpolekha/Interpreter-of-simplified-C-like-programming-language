using System;

namespace Exceptions
{

    public class ClosingQuoteExpectedError : Error
    {

        const string msg = "Closing quote is expected";
        
        public ClosingQuoteExpectedError()
        { }

        public ClosingQuoteExpectedError(uint line, uint column) : this(msg, line, column)
        { }
        public ClosingQuoteExpectedError(string message, uint line, uint column) : base(message, line, column)
        { }

        public ClosingQuoteExpectedError( Exception innerException) : this(msg, innerException)
        { }
        public ClosingQuoteExpectedError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}