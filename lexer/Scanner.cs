using System;
using System.Text;
using Exceptions;
namespace Lexer.Scanner
{
    using Lexer.Source;
    using Lexer.Token;

    public class Scanner
    {
        Source source;
        char current;
        uint line;
        uint position;
        uint tokenLine;
        uint tokenPosition;

        readonly ulong MAX_INT;
        readonly uint MAX_STRING_LEN;
        readonly uint MAX_IDENT_LEN;
        public readonly uint MAX_ZERO_NUM;

        public Scanner(Source source, ulong MAX_INT = 2147483447, uint MAX_STRING_LEN = 2048, uint MAX_IDENT_LEN = 25, uint MAX_ZERO_NUM = 10)
        {
            //constants initialization
            this.MAX_INT = MAX_INT;
            this.MAX_STRING_LEN = MAX_STRING_LEN;
            this.MAX_IDENT_LEN = MAX_IDENT_LEN;
            this.MAX_ZERO_NUM = MAX_ZERO_NUM;


            this.source = source;
            this.line = 1;
            this.position = 0;
            advance();
        }
        private bool advance()
        {
            current = source.ReadNextSymbol();
            if (current == '\n') // obsługa różnych typów nowej linii
            {
                line += 1;
                position = 0;
            }
            else
            {
                position += 1;
                if (current < 1)
                {
                    return false;
                }
            }
            return true;

        }
        void skipWhitespace()
        {
            while (char.IsWhiteSpace(current))
            {
                advance();
            }
        }
        public Token GetNextToken()
        {
            skipWhitespace();
            this.tokenLine = this.line;
            this.tokenPosition = this.position;
            Token token;

            token = getEndToken();
            if (!(token is null)) return token;
            token = getOperatorToken();
            if (!(token is null)) return token;
            token = getSeparatorToken();
            if (!(token is null)) return token;
            token = getNumberToken();
            if (!(token is null)) return token;
            token = getIdentOrKeywordToken();
            if (!(token is null)) return token;
            token = getTextToken();
            if (!(token is null)) return token;

            //Symbol is unknown
            throw new UnknownSymbolError(line, position);
        }
        Token getEndToken()
        {
            if (current < 1)
            {
                return new Token(Token.TokenType.T_END, "", tokenLine, tokenPosition);
            }
            return null;
        }
        Token getOperatorToken()
        {
            switch (current)
            {
                case '+':
                    advance();
                    return new Token(Token.TokenType.T_PLUS, "+", tokenLine, tokenPosition);
                case '-':
                    advance();
                    return new Token(Token.TokenType.T_MINUS, "-", tokenLine, tokenPosition);
                case '%':
                    advance();
                    return new Token(Token.TokenType.T_MODULO, "%", tokenLine, tokenPosition);
                case '*':
                    advance();
                    return new Token(Token.TokenType.T_MUL, "*", tokenLine, tokenPosition);
                case '/':
                    advance();
                    return new Token(Token.TokenType.T_DIV, "/", tokenLine, tokenPosition);
                case '=':
                    advance();
                    if (current == '=')
                    {
                        advance();
                        return new Token(Token.TokenType.T_EQUALS, "==", tokenLine, tokenPosition);
                    }
                    else
                    {
                        return new Token(Token.TokenType.T_ASSIGN, "=", tokenLine, tokenPosition);
                    }
                case '!':
                    advance();
                    if (current == '=')
                    {
                        advance();
                        return new Token(Token.TokenType.T_NEQUALS, "!=", tokenLine, tokenPosition);
                    }
                    else
                    {
                        return new Token(Token.TokenType.T_NOT, "!", tokenLine, tokenPosition);
                    }
                case '>':
                    advance();
                    if (current == '=')
                    {
                        advance();
                        return new Token(Token.TokenType.T_MOREEQUALS, ">=", tokenLine, tokenPosition);
                    }
                    else
                    {
                        return new Token(Token.TokenType.T_MORETHAN, ">", tokenLine, tokenPosition);
                    }
                case '<':
                    advance();
                    if (current == '=')
                    {
                        advance();
                        return new Token(Token.TokenType.T_LESSEQUALS, "<=", tokenLine, tokenPosition);
                    }
                    else
                    {
                        return new Token(Token.TokenType.T_LESSTHAN, "<", tokenLine, tokenPosition);
                    }
                case '&':
                    advance();
                    if (current == '&')
                    {
                        advance();
                        return new Token(Token.TokenType.T_AND, "&&", tokenLine, tokenPosition);
                    }
                    else
                    {
                        // Invalid operator AND
                        throw new InvalidOperatorError(tokenLine, tokenPosition);
                    }
                case '|':
                    advance();
                    if (current == '|')
                    {
                        advance();
                        return new Token(Token.TokenType.T_OR, "||", tokenLine, tokenPosition);
                    }
                    else
                    {
                        // Invalid operator OR
                        
                        throw new InvalidOperatorError(tokenLine, tokenPosition);
                    }

            }

            return null;
        }

        Token getSeparatorToken()
        {
            switch (current)
            {
                case ')':
                    advance();
                    return new Token(Token.TokenType.T_RPARENT, ")", tokenLine, tokenPosition);
                case '(':
                    advance();
                    return new Token(Token.TokenType.T_LPARENT, "(", tokenLine, tokenPosition);
                case '}':
                    advance();
                    return new Token(Token.TokenType.T_RBRACE, "}", tokenLine, tokenPosition);
                case '{':
                    advance();
                    return new Token(Token.TokenType.T_LBRACE, "{", tokenLine, tokenPosition);
                case ']':
                    advance();
                    return new Token(Token.TokenType.T_RSBRACKET, "]", tokenLine, tokenPosition);
                case '[':
                    advance();
                    return new Token(Token.TokenType.T_LSBRACKET, "[", tokenLine, tokenPosition);
                case ';':
                    advance();
                    return new Token(Token.TokenType.T_SEMICOLON, ";", tokenLine, tokenPosition);
                case ',':
                    advance();
                    return new Token(Token.TokenType.T_COMMA, ",", tokenLine, tokenPosition);
                case '.':
                    advance();
                    if (current == '.')
                    {
                        advance();
                        if (current == '.')
                        {
                            advance();
                            return new Token(Token.TokenType.T_ELLIPSIS, "...", tokenLine, tokenPosition);
                        }
                        else
                        {
                            // ELLIPIS is not recognised
                            throw new InvalidOperatorError(tokenLine, tokenPosition);

                        }

                    }
                    else
                    {
                        return new Token(Token.TokenType.T_DOT, ".", tokenLine, tokenPosition);
                    }
            }

            return null;
        }

        Token getNumberToken()
        {
            if (Char.IsDigit(current))
            {
                ulong number = 0;
                uint i = 0;
                while (Char.IsDigit(current) && current == '0' && i <= this.MAX_ZERO_NUM)
                {
                    advance();
                    i++;
                }
                if (i > this.MAX_ZERO_NUM)
                {
                    //Limit of zeros
                    throw new ZerosOutOfLimitError(tokenLine, tokenPosition);
                }

                while (Char.IsDigit(current))
                {
                    number = number * 10 + Convert.ToByte(current - '0');
                    if (number > this.MAX_INT)
                    {
                        //Number is too big
                        throw new NumberOutOfRangeError(tokenLine, tokenPosition);
                    }
                    else
                    {
                        advance();
                    }
                }

                return new Token(Token.TokenType.T_INTCONST, number, tokenLine, tokenPosition);
            }
            else
            {
                return null;
            }
        }

        Token getIdentOrKeywordToken()
        {
            if (Char.IsLetter(current))
            {
                StringBuilder stringBuilder = new StringBuilder();
                do
                {
                    stringBuilder.Append(current);
                    advance();
                } while ((Char.IsLetterOrDigit(current) || current == '_') && stringBuilder.Length <= this.MAX_IDENT_LEN);

                if (stringBuilder.Length <= this.MAX_IDENT_LEN)
                {
                    if (Token.key.TryGetValue(stringBuilder.ToString(), out Token.TokenType tokenType))
                    {
                        return new Token(tokenType, stringBuilder.ToString(), tokenLine, tokenPosition);
                    }
                    else
                    {
                        return new Token(Token.TokenType.T_IDENTIFIER, stringBuilder.ToString(), tokenLine, tokenPosition);
                    }
                }
                else
                {
                    //Identifier is too long!");
                    throw new IdentifierTooLongError(tokenLine, tokenPosition);
                }
            }
            else
            {
                return null;
            }
        }

        Token getTextToken()
        {
            if (current == '"')
            {
                advance();
                StringBuilder stringBuilder = new StringBuilder();

                while (current != '"')
                {
                    if (current < 1)
                    {
                        //END in text found
                        throw new ClosingQuoteExpectedError(line, position);
                    }
                    if (stringBuilder.Length >= this.MAX_STRING_LEN)
                    {
                        //String is too long
                        throw new TextTooLongError(tokenLine, tokenPosition);
                    }


                    if (current == '\\') // "\*"
                    {
                        advance();
                        if (current == '"') // switch(current){case '"': case 't':}
                        {
                            stringBuilder.Append('"');
                            advance();
                        }
                        else
                        {
                            stringBuilder.Append('\\'); // current == 't' a chcemy żeby było wstawione '\t'
                        }
                    }
                    else
                    {
                        stringBuilder.Append(current);
                        advance();
                    }
                }
                advance();
                return new Token(Token.TokenType.T_TEXT, stringBuilder.ToString(), tokenLine, tokenPosition);


            }
            return null;
        }

    }
}