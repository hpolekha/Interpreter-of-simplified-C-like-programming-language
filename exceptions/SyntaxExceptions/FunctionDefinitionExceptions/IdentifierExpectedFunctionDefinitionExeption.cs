using System;

namespace Exceptions
{
    public class IdentifierExpectedFunctionDefinitionException : SyntaxException
    {
        const string msg = "Identifier expected in the declaration of function";

        public IdentifierExpectedFunctionDefinitionException()
        { }

        public IdentifierExpectedFunctionDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public IdentifierExpectedFunctionDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public IdentifierExpectedFunctionDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public IdentifierExpectedFunctionDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}