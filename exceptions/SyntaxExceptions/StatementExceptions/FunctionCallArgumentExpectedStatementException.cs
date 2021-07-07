using System;

namespace Exceptions
{
    public class FunctionCallArgumentExpectedStatementException : SyntaxException
    {
        const string msg = "Argument is expected in the function call";

        public FunctionCallArgumentExpectedStatementException()
        { }

        public FunctionCallArgumentExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public FunctionCallArgumentExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public FunctionCallArgumentExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public FunctionCallArgumentExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}