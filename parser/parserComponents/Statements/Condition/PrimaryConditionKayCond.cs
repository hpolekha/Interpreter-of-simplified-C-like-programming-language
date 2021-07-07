using System;
public class PrimaryConditionKayCond : PrimaryConditionKay
{
    Condition condition;
    public PrimaryConditionKayCond(bool ifNegated, Condition condition) : base(ifNegated)
    {
        this.condition = condition;
        // Console.WriteLine("PrimaryCondKayCond created");
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

        PrimaryConditionKayCond another = (PrimaryConditionKayCond)obj;

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