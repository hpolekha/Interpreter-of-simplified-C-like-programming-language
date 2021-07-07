using System;

namespace Exceptions
{
    public class ParameterRedefinitionFunctionDefinitionException : SyntaxException
    {
        const string msg = "Multiple definition of enum";

        public ParameterRedefinitionFunctionDefinitionException()
        { }

        public ParameterRedefinitionFunctionDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public ParameterRedefinitionFunctionDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ParameterRedefinitionFunctionDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public ParameterRedefinitionFunctionDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}