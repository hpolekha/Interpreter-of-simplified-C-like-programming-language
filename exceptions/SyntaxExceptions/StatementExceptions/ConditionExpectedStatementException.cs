using System;

namespace Exceptions
{
    public class ConditionExpectedStatementException : SyntaxException
    {
        const string msg = "Condition is expected in the statement";

        public ConditionExpectedStatementException()
        { }

        public ConditionExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public ConditionExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public ConditionExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public ConditionExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}