using System;
public class LoopStatement : Statement
{
    Condition condition;
    Block block;

    public LoopStatement(Condition condition, Block block)
    {
        this.condition = condition;
        this.block = block;

        // Console.WriteLine("LoopBlock created");
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

        LoopStatement another = (LoopStatement)obj;

        if (this.condition == null && another.condition != null)
        {
            return false;
        }
        if (this.condition != null && !this.condition.Equals(another.condition))
        {
            return false;
        }

        if (this.block == null && another.block != null)
        {
            return false;
        }
        if (this.block != null && !this.block.Equals(another.block))
        {
            return false;
        }


        return true;

    }
}