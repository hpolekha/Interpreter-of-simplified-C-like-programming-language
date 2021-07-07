using System;

namespace Exceptions
{
    public class EnumeratorRedefinitionEnumDefinitionException : SyntaxException
    {
        const string msg = "Redefinition of enumerator";

        public EnumeratorRedefinitionEnumDefinitionException()
        { }

        public EnumeratorRedefinitionEnumDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public EnumeratorRedefinitionEnumDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public EnumeratorRedefinitionEnumDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public EnumeratorRedefinitionEnumDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}