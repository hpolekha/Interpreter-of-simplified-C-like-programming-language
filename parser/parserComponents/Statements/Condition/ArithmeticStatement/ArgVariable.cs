public class ArgVariable : ArithmeticArg
{
    string varName;

    public ArgVariable(string varName)
    {
        this.varName = varName;
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

        ArgVariable another = (ArgVariable)obj;

        if (this.varName != another.varName)
        {
            return false;
        }


        return true;

    }
}