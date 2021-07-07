using System;

namespace Exceptions
{
    public class IllegalVarAssignmentStatementException : SyntaxException
    {
        const string msg = "Illegal variable assignment";

        public IllegalVarAssignmentStatementException()
        { }

        public IllegalVarAssignmentStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public IllegalVarAssignmentStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public IllegalVarAssignmentStatementException(Exception innerException) : this(msg, innerException)
        { }
        public IllegalVarAssignmentStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}