
using System;

namespace Exceptions
{
    public class EnumeratorListUnfinshedEnumDefinitionException : SyntaxException
    {
        const string msg = "List of enumerator definitions is unfinished";

        public EnumeratorListUnfinshedEnumDefinitionException()
        { }

        public EnumeratorListUnfinshedEnumDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public EnumeratorListUnfinshedEnumDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public EnumeratorListUnfinshedEnumDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public EnumeratorListUnfinshedEnumDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}