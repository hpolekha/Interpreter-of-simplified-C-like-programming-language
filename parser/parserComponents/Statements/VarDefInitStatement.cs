using Lexer.Token;
using System;
public class VarDefInitStatement : Statement
{
    Token.TokenType type;
    string typeEnumName;
    string name;

    Condition condition;

    public VarDefInitStatement(Token.TokenType type, string name)
                        : this(type, null, name, null) { }
    public VarDefInitStatement(Token.TokenType type, string name, Condition condition)
                        : this(type, null, name, condition) { }
    public VarDefInitStatement(string typeEnumName, string name)
                        : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name, null) { }
    public VarDefInitStatement(string typeEnumName, string name, Condition condition)
                        : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name, condition) { }



    public VarDefInitStatement(Token.TokenType type, string typeEnumName, string name, Condition condition)
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
        this.condition = condition;

        // Console.WriteLine("VarDefInitStatement type = " + this.type + ", typeEnumN = " + this.typeEnumName + ", name = " + name);

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

        VarDefInitStatement another = (VarDefInitStatement)obj;

        if (this.condition == null && another.condition != null)
        {
            return false;
        }
        if (this.condition != null && !this.condition.Equals(another.condition))
        {
            return false;
        }
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