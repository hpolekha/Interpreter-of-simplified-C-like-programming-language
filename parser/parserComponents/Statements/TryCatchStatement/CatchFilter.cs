public class CatchFilter
{
    Condition leftCondition;
    Condition rightCondition;

    public CatchFilter(Condition leftCondition) : this(leftCondition, null) { }
    public CatchFilter(Condition leftCondition, Condition rightCondition)
    {
        this.leftCondition = leftCondition;
        this.rightCondition = rightCondition;
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

        CatchFilter another = (CatchFilter)obj;

        if (this.leftCondition == null && another.leftCondition != null)
        {
            return false;
        }
        if (this.leftCondition != null && !this.leftCondition.Equals(another.leftCondition))
        {
            return false;
        }

        if (this.rightCondition == null && another.rightCondition != null)
        {
            return false;
        }
        if (this.rightCondition != null && !this.rightCondition.Equals(another.rightCondition))
        {
            return false;
        }

        return true;

    }

}