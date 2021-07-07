using System;

namespace Exceptions
{
    public class EnumeratorInitializerExpectedEnumDefinitionException : SyntaxException
    {
        const string msg = "Initializer of an enumerator is expected";

        public EnumeratorInitializerExpectedEnumDefinitionException()
        { }

        public EnumeratorInitializerExpectedEnumDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public EnumeratorInitializerExpectedEnumDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public EnumeratorInitializerExpectedEnumDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public EnumeratorInitializerExpectedEnumDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}