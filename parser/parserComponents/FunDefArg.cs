using Lexer.Token;
using System;
public class FunDefArg
{
    Token.TokenType type;
    string typeEnumName;
    string name;

    public FunDefArg(Token.TokenType type, string name) : this(type, null, name) { }

    public FunDefArg(string typeEnumName, string name) : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name) { }
    public FunDefArg(Token.TokenType type, string typeEnumName, string name)
    {
        this.type = type;
        if (this.type == Token.TokenType.T_IDENTIFIER)
        {
            this.typeEnumName = typeEnumName;
        }
        else
        {
            this.typeEnumName = null;
        }
        this.name = name;

        // Console.WriteLine("FundefArg type = " + this.type.ToString() + ", typeenumname = " + this.typeEnumName + ", name = " + this.name);
    }


    public override bool Equals(object obj)
    {
        if (this == obj)
        {
            return true;
        }
        if (obj == null)
        {
            return false;
        }

        if (this.GetType() != obj.GetType())
        {
            return false;
        }

        FunDefArg another = (FunDefArg)obj;

        if (this.name != another.name)
        {
            return false;
        }
        if (this.typeEnumName != another.typeEnumName)
        {
            return false;
        }

        if (this.type != another.type)
        {
            return false;

        }

        return true;

    }
}