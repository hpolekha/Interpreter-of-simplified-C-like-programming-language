using System;
public class PrimaryConditionKayArithm : PrimaryConditionKay
{
    ArithmeticStatement arithmeticStatement;
    public PrimaryConditionKayArithm(bool ifNegated, ArithmeticStatement arithmeticStatement) : base(ifNegated)
    {
        this.arithmeticStatement = arithmeticStatement;
        // Console.WriteLine("PrimaryCondKayArith created");
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

        PrimaryConditionKayArithm another = (PrimaryConditionKayArithm)obj;

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