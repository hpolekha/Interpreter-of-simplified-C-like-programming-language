using System;

namespace Exceptions
{
    public class UnknownEnumeratorSyntaxException : SyntaxException
    {
        const string msg = "Operand is expected";

        public UnknownEnumeratorSyntaxException()
        { }

        public UnknownEnumeratorSyntaxException(uint line, uint column) : this(msg, line, column)
        { }
        public UnknownEnumeratorSyntaxException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UnknownEnumeratorSyntaxException(Exception innerException) : this(msg, innerException)
        { }
        public UnknownEnumeratorSyntaxException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}