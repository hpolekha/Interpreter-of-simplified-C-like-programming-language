using System;
using System.IO;

namespace Lexer.Source
{
    
    public class Source
    {

        TextReader textReader;
        public Source(string sourceString)
        {
            this.textReader = new StringReader(sourceString);
        }
        public Source(StreamReader streamReader)
        {
            this.textReader = streamReader;
        }
        public Source(TextReader textReader)
        {
            this.textReader = textReader;
        }
        public char ReadNextSymbol()
        {
            char result = '\0';
            if (this.textReader.Peek() > -1)
            {
                result = (char)textReader.Read();
            }
            return result;
        }
    }
}



    