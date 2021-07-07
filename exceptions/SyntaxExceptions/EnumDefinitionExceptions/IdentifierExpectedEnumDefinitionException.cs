using System;

namespace Exceptions
{
    public class IdentifierExpectedEnumDefinitionException : SyntaxException
    {
        const string msg = "Identifier expected in the declaration of enum";

        public IdentifierExpectedEnumDefinitionException()
        { }

        public IdentifierExpectedEnumDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public IdentifierExpectedEnumDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public IdentifierExpectedEnumDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public IdentifierExpectedEnumDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}