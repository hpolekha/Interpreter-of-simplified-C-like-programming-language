using System;

namespace Exceptions
{
    public class IncompatibleDataTypesLogicException : LogicException
    {
        const string msg = "Incompatible datatypes";

        public IncompatibleDataTypesLogicException()
        { }

        public IncompatibleDataTypesLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public IncompatibleDataTypesLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public IncompatibleDataTypesLogicException(Exception innerException) : this(msg, innerException)
        { }
        public IncompatibleDataTypesLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}