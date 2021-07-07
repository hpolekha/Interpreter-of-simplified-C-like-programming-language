public class ArgEnumNameExtended : ArithmeticArg
{
    string parent;
    string name;

    public ArgEnumNameExtended(string parent, string name)
    {
        this.parent = parent;
        this.name = name;
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

        ArgEnumNameExtended another = (ArgEnumNameExtended)obj;
        if (this.name != another.name)
        {
            return false;
        }
        if (this.parent != another.parent)
        {
            return false;
        }

        return true;

    }
}