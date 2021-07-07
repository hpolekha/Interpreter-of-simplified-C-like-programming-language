using System;

namespace Exceptions
{

    public class TextTooLongError : Error
    {

        const string msg = "Text is too long";
        
        public TextTooLongError()
        { }

        public TextTooLongError(uint line, uint column) : this(msg, line, column)
        { }
        public TextTooLongError(string message, uint line, uint column) : base(message, line, column)
        { }

        public TextTooLongError( Exception innerException) : this(msg, innerException)
        { }
        public TextTooLongError(string message, Exception innerException) : base(message, innerException)
        { }

    }
}