using System;

namespace Exceptions
{
    public class FaliledDetermineDefaultValueLogicException : LogicException
    {
        const string msg = "Faild to determine default value";

        public FaliledDetermineDefaultValueLogicException()
        { }

        public FaliledDetermineDefaultValueLogicException(uint line, uint column) : this(msg, line, column)
        { }
        public FaliledDetermineDefaultValueLogicException(string message, uint line, uint column) : base(message, line, column)
        { }

        public FaliledDetermineDefaultValueLogicException(Exception innerException) : this(msg, innerException)
        { }
        public FaliledDetermineDefaultValueLogicException(string message, Exception innerException) : base(message, innerException)
        { }
    }

}