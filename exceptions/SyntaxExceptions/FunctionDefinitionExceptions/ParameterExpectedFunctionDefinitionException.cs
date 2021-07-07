using System;

namespace Exceptions
{
    public class ParameterExpectedFunctionDefinitionException : SyntaxException
    {
        const string msg = "Parameter expected in the declaration of function";

        public ParameterExpectedFunctionDefinitionException()
        { }

        public ParameterExpectedFunctionDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public ParameterExpectedFunctionDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ParameterExpectedFunctionDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public ParameterExpectedFunctionDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}