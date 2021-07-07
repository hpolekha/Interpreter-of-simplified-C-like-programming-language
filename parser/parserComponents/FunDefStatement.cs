using Lexer.Token;
using System.Collections.Generic;
using System;
using System.Linq;
public class FunDefStatement
{
    string name;
    Token.TokenType returnType;
    string returnTypeEnumName;
    List<FunDefArg> funDefArgs;
    Block block;

    public FunDefStatement(Token.TokenType returnType, string returnTypeEnumName, string name, List<FunDefArg> funDefArgs, Block block)
    {
        this.returnType = returnType;
        if (this.returnType == Token.TokenType.T_IDENTIFIER)
        {
            this.returnTypeEnumName = returnTypeEnumName;
        }
        else
        {
            this.returnTypeEnumName = null;
        }
        this.funDefArgs = funDefArgs;
        this.block = block;

        // Console.WriteLine("FUndefStatemet retType = " + returnType + ", enumname =" + returnTypeEnumName + " , name = " + name);
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

        FunDefStatement another = (FunDefStatement)obj;

        if (this.funDefArgs == null && another.funDefArgs != null)
        {
            return false;
        }
        if (this.funDefArgs != null && !this.funDefArgs.SequenceEqual(another.funDefArgs))
        {
            return false;
        }

        if (this.block == null && another.block != null)
        {
            return false;
        }
        if (this.block != null && !this.block.Equals(another.block))
        {
            return false;
        }
        if (this.name != another.name)
        {
            return false;
        }
        if (this.returnTypeEnumName != another.returnTypeEnumName)
        {
            return false;
        }

        if (this.returnType != another.returnType)
        {
            return false;
        }

        return true;

    }
}