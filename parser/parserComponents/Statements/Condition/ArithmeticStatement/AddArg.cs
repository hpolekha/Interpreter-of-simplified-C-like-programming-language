using Lexer.Token;
using System.Collections.Generic;
using System.Linq;
using System;
public class AddArg
{
    Token.TokenType sign;
    List<ArithmeticArg> arithmeticArgs;

    public AddArg(List<ArithmeticArg> arithmeticArgs) : this(Token.TokenType.T_PLUS, arithmeticArgs)
    {
    }
    public AddArg(Token.TokenType sign, List<ArithmeticArg> arithmeticArgs)
    {
        this.sign = sign;
        this.arithmeticArgs = arithmeticArgs;
        // Console.WriteLine("AddArg created");

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

        AddArg another = (AddArg)obj;

        if (this.arithmeticArgs == null && another.arithmeticArgs != null)
        {
            return false;
        }
        if (this.arithmeticArgs != null && !this.arithmeticArgs.SequenceEqual(another.arithmeticArgs))
        {
            return false;
        }

        if (this.sign != another.sign)
        {
            return false;
        }

        return true;

    }


}