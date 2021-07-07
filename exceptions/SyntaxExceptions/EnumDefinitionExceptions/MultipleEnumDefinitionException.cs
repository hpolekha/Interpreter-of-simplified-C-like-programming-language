using System;

namespace Exceptions
{
    public class MultipleEnumDefinitionException : SyntaxException
    {
        const string msg = "Multiple definition of enum";

        public MultipleEnumDefinitionException()
        { }

        public MultipleEnumDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public MultipleEnumDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public MultipleEnumDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public MultipleEnumDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}