using System;
public class ThrowStatement : Statement
{
    Condition argument;

    public ThrowStatement(Condition argument)
    {
        this.argument = argument;

        // Console.WriteLine("ThrowStatement was created");
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

        ThrowStatement another = (ThrowStatement)obj;

        if (this.argument == null && another.argument != null)
        {
            return false;
        }
        if (this.argument != null && !this.argument.Equals(another.argument))
        {
            return false;
        }

        return true;

    }
}