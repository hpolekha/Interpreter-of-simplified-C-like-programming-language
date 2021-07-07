using System;

public class VarAssignStatement : Statement
{
    string name;
    Condition condition;

    public VarAssignStatement(string name, Condition condition)
    {
        this.name = name;
        this.condition = condition;

        // Console.WriteLine("VarAssignStatement name = " + name);
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

        VarAssignStatement another = (VarAssignStatement)obj;

        if (this.condition == null && another.condition != null)
        {
            return false;
        }
        if (this.condition != null && !this.condition.Equals(another.condition))
        {
            return false;
        }

        return true;

    }

}