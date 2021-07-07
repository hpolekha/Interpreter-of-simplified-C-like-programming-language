public class ArgFunCallStatement : ArithmeticArg
{
    FunCallStatement funCallStatement;

    public ArgFunCallStatement(FunCallStatement funCallStatement)
    {
        this.funCallStatement = funCallStatement;
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

        ArgFunCallStatement another = (ArgFunCallStatement)obj;

        if (this.funCallStatement == null && another.funCallStatement != null)
        {
            return false;
        }
        if (this.funCallStatement != null && !this.funCallStatement.Equals(another.funCallStatement))
        {
            return false;
        }

        return true;

    }
}