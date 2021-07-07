using System;

namespace Exceptions
{
    [Serializable]
    public class Error : Exception
    {

        uint line;
        uint column;

        public Error()
        { }

        public Error(string message, uint line, uint column)
            : base(message)
        {
            this.line = line;
            this.column = column;
        }

        public Error(string message, Exception innerException)
            : base(message, innerException)
        { }

        public override string ToString()
        {
            return string.Format("({0}:{1}) {2}: {3}\r", line, column, this.GetType().Name, this.Message);
        }


        public string getMessage()
        {
            return "(" + line + ":" + column + ") Error: " + Message;
        }

    }
}


