using System.Collections.Generic;
using System;

namespace Lexer.Token
{
    public class Token
    {
        public enum TokenType
        {
            T_END,
            T_LBRACE,
            T_RBRACE,
            T_LPARENT,
            T_RPARENT,
            T_LSBRACKET,
            T_RSBRACKET,
            T_IDENTIFIER,
            T_INCLUDE,
            T_INTCONST,
            T_TEXT,
            T_ASSIGN,
            T_ENUM,
            T_INT,
            T_STRING,
            T_IF,
            T_WHILE,
            T_ELSE,
            T_EQUALS,
            T_NEQUALS,
            T_MORETHAN,
            T_LESSTHAN,
            T_MOREEQUALS,
            T_LESSEQUALS,
            T_THROW,
            T_DOT,
            T_ELLIPSIS,
            T_SEMICOLON,
            T_COMMA,
            T_RETURN,
            T_MODULO,
            T_VOID,
            T_TRY,
            T_CATCH,
            T_MINUS,
            T_PLUS,
            T_DIV,
            T_MUL,
            T_AND,
            T_OR,
            T_NOT
        }

        TokenType type;
        Object value;
        uint line;
        uint position;

        public static Dictionary<string, TokenType> key;

        public Token(TokenType type, String value, uint line, uint position)
        {
            this.type = type;
            this.value = value;
            this.line = line;
            this.position = position;
        }
        public Token(TokenType type, ulong value, uint line, uint position)
        {
            this.type = type;
            this.value = value;
            this.line = line;
            this.position = position;
        }
        static Token()
        {
            key = new Dictionary<string, TokenType>();
            KeyInit();
        }

        static void KeyInit()
        {
            key.Add("enum", TokenType.T_ENUM);
            key.Add("int", TokenType.T_INT);
            key.Add("string", TokenType.T_STRING);
            key.Add("if", TokenType.T_IF);
            key.Add("while", TokenType.T_WHILE);
            key.Add("else", TokenType.T_ELSE);
            key.Add("throw", TokenType.T_THROW);
            key.Add("return", TokenType.T_RETURN);
            key.Add("void", TokenType.T_VOID);
            key.Add("try", TokenType.T_TRY);
            key.Add("catch", TokenType.T_CATCH);
            // extended
            key.Add("{", TokenType.T_LBRACE);
            key.Add("}", TokenType.T_RBRACE);
            key.Add("(", TokenType.T_LPARENT);
            key.Add(")", TokenType.T_RPARENT);
            key.Add("[", TokenType.T_LSBRACKET);
            key.Add("]", TokenType.T_RSBRACKET);
            key.Add("=", TokenType.T_ASSIGN);
            key.Add("==", TokenType.T_EQUALS);
            key.Add("!=", TokenType.T_NEQUALS);
            key.Add(">", TokenType.T_MORETHAN);
            key.Add("<", TokenType.T_LESSTHAN);
            key.Add(">=", TokenType.T_MOREEQUALS);
            key.Add("<=", TokenType.T_LESSEQUALS);
            key.Add(".", TokenType.T_DOT);
            key.Add("...", TokenType.T_ELLIPSIS);
            key.Add(";", TokenType.T_SEMICOLON);
            key.Add("%", TokenType.T_MODULO);
            key.Add("-", TokenType.T_MINUS);
            key.Add("+", TokenType.T_PLUS);
            key.Add("/", TokenType.T_DIV);
            key.Add("*", TokenType.T_MUL);
            key.Add("&&", TokenType.T_AND);
            key.Add("||", TokenType.T_OR);
            key.Add("!", TokenType.T_NOT);
            key.Add(",", TokenType.T_COMMA);
        }

        public TokenType GetType()
        {
            return this.type;
        }

        public Object GetValue()
        {
            return this.value;
        }
        
        public uint GetPosition()
        {
            return this.position;
        }
        public uint GetLine()
        {
            return this.line;
        }

        public static bool operator ==(Token lt, Token rt)
        {
            return (lt.type == rt.type) && (lt.value.Equals(rt.value)) && (lt.line == rt.line) && (lt.position == rt.position); 
        }
        public static bool operator !=(Token lt, Token rt)
        {
            return (lt.type != rt.type) || (!lt.value.Equals(rt.value)) || (lt.line != rt.line) || (lt.position != rt.position);
        }

    }
}

