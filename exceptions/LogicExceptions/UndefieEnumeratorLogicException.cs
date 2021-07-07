using System;

namespace Exceptions
{
    public class UndefineEnumeratorLogicException : LogicException
    {
        const string msg = "Undefine enumerator";

        public UndefineEnumeratorLogicException()
        { }

        public UndefineEnumeratorLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public UndefineEnumeratorLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public UndefineEnumeratorLogicException(Exception innerException) : this(msg, innerException)
        { }
        public UndefineEnumeratorLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}