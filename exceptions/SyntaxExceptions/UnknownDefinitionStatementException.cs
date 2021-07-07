using System;

namespace Exceptions
{
    public class UnknownDefinitionStatement : SyntaxException
    {
        const string msg = "Unknown definition statement";

        public UnknownDefinitionStatement()
        { }

        public UnknownDefinitionStatement(uint line, uint column) : this(msg, line, column)
        { }
        public UnknownDefinitionStatement(string message, uint line, uint column) : base(message, line, column)
        { }

        public UnknownDefinitionStatement(Exception innerException) : this(msg, innerException)
        { }
        public UnknownDefinitionStatement(string message, Exception innerException) : base(message, innerException)
        { }
    }

}