using System;

namespace Exceptions
{

    public class IdentifierTooLongError : Error
    {

        const string msg = "Identifier is too long";
        
        public IdentifierTooLongError()
        { }

        public IdentifierTooLongError(uint line, uint column) : this(msg, line, column)
        { }
        public IdentifierTooLongError(string message, uint line, uint column) : base(message, line, column)
        { }

        public IdentifierTooLongError( Exception innerException) : this(msg, innerException)
        { }
        public IdentifierTooLongError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}