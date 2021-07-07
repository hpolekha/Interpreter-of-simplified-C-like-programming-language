using System;
public class ArgNumber : ArithmeticArg
{
    ulong number;

    public ArgNumber(ulong number)
    {
        this.number = number;
       // Console.WriteLine("ArgNum num = " + number);
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

        ArgNumber another = (ArgNumber)obj;

        if (this.number != another.number)
        {
            return false;

        }

        return true;

    }
}