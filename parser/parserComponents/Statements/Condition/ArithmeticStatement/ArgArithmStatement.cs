using System;
public class ArgArithmStatement : ArithmeticArg
{
    ArithmeticStatement arithmeticStatement;


    public ArgArithmStatement(ArithmeticStatement arithmeticStatement)
    {
        this.arithmeticStatement = arithmeticStatement;
        // Console.WriteLine("ArgArithmStatemet created");
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

        ArgArithmStatement another = (ArgArithmStatement)obj;

        if (this.arithmeticStatement == null && another.arithmeticStatement != null)
        {
            return false;
        }
        if (this.arithmeticStatement != null && !this.arithmeticStatement.Equals(another.arithmeticStatement))
        {
            return false;
        }

        return true;

    }
}