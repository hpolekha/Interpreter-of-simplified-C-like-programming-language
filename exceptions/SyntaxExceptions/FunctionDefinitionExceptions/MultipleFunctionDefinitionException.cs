using System;

namespace Exceptions
{
    public class MultipleFunctionDefinitionException : SyntaxException
    {
        const string msg = "Multiple definition of function";

        public MultipleFunctionDefinitionException()
        { }

        public MultipleFunctionDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public MultipleFunctionDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public MultipleFunctionDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public MultipleFunctionDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}