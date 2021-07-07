using System;

namespace Exceptions
{
    public class VariableRedeclarationLogicException : LogicException
    {
        const string msg = "Variable already exsits";

        public VariableRedeclarationLogicException()
        { }

        public VariableRedeclarationLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public VariableRedeclarationLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public VariableRedeclarationLogicException(Exception innerException) : this(msg, innerException)
        { }
        public VariableRedeclarationLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}