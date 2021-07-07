using System;

namespace Exceptions
{
    public class BlockExpectedStatementException : SyntaxException
    {
        const string msg = "Block is expected in the statement";

        public BlockExpectedStatementException()
        { }

        public BlockExpectedStatementException(uint line, uint column) : this(msg, line, column)
        { }
        public BlockExpectedStatementException(string message, uint line, uint column) : base(message, line, column)
        { }

        public BlockExpectedStatementException(Exception innerException) : this(msg, innerException)
        { }
        public BlockExpectedStatementException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}