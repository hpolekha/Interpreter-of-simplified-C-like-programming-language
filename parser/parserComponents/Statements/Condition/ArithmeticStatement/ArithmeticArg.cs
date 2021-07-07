using Lexer.Token;
using System;
public class ArithmeticArg
{
    Token.TokenType? multOperator;
    Token.TokenType sign;

    public ArithmeticArg() : this(null, Token.TokenType.T_PLUS) { }
    public ArithmeticArg(Token.TokenType? multOperator, Token.TokenType sign)
    {
        this.multOperator = multOperator;
        this.sign = sign;
        // Console.WriteLine("ArithmArg mulOp = " + multOperator.ToString() + " sign = " + sign.ToString());

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

        ArithmeticArg another = (ArithmeticArg)obj;

        if (this.multOperator == null && another.multOperator != null)
        {
            return false;
        }
        if (this.multOperator != null && this.multOperator != (another.multOperator))
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