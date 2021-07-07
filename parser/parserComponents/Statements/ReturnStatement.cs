using System;
public class ReturnStatement : Statement
{
    Condition argument;

    public ReturnStatement(Condition argument)
    {
        this.argument = argument;

        // Console.WriteLine("ReturnStatement was created");
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

        ReturnStatement another = (ReturnStatement)obj;

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