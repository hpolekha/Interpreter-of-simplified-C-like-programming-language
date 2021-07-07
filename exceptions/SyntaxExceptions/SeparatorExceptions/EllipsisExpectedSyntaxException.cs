using System;

namespace Exceptions
{

    public class EllipsisExpectedException : SyntaxException
    {

        const string msg = "Ellipsis is expected";

        public EllipsisExpectedException()
        { }

        public EllipsisExpectedException(uint line, uint column) : this(msg, line, column)
        { }
        public EllipsisExpectedException(string message, uint line, uint column) : base(message, line, column)
        { }

        public EllipsisExpectedException(Exception innerException) : this(msg, innerException)
        { }
        public EllipsisExpectedException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}