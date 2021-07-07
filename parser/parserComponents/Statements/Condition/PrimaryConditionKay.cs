using System;
public class PrimaryConditionKay
{
    bool ifNegated;
    public PrimaryConditionKay(bool ifNegated)
    {
        this.ifNegated = ifNegated;

        //Console.WriteLine("PrimaryCondKay created");
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

        PrimaryConditionKay another = (PrimaryConditionKay)obj;

        if (this.ifNegated != another.ifNegated)
        {
            return false;

        }

        return true;

    }

}
