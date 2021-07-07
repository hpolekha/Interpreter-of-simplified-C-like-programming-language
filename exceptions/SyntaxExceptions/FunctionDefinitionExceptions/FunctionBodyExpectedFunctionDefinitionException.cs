using System;

namespace Exceptions
{
    public class FunctionBodyExpectedFunctionDefinitionException : SyntaxException
    {
        const string msg = "Function body is expected in the declaration of function";

        public FunctionBodyExpectedFunctionDefinitionException()
        { }

        public FunctionBodyExpectedFunctionDefinitionException(uint line, uint column) : this(msg, line, column)
        { }
        public FunctionBodyExpectedFunctionDefinitionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public FunctionBodyExpectedFunctionDefinitionException(Exception innerException) : this(msg, innerException)
        { }
        public FunctionBodyExpectedFunctionDefinitionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}