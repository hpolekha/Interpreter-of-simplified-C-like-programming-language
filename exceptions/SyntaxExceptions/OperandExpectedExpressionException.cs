using System;

namespace Exceptions
{
    public class OperandExpectedExpressionException : SyntaxException
    {
        const string msg = "Operand is expected";

        public OperandExpectedExpressionException()
        { }

        public OperandExpectedExpressionException(uint line, uint column) : this(msg, line, column)
        { }
        public OperandExpectedExpressionException(string message, uint line, uint column) : base(message, line, column)
        { }

        public OperandExpectedExpressionException(Exception innerException) : this(msg, innerException)
        { }
        public OperandExpectedExpressionException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}