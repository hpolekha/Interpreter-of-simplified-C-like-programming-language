using System;
using System.Collections.Generic;
using System.Linq;
public class TryCatchStatement : Statement
{
    Block tryBlock;
    List<Catch> catches;

    public TryCatchStatement(Block tryBlock, List<Catch> catches)
    {
        this.tryBlock = tryBlock;
        this.catches = catches;

        // Console.WriteLine("TryCatchStatement num of catches: " + this.catches.Count);
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

        TryCatchStatement another = (TryCatchStatement)obj;

        if (this.tryBlock == null && another.tryBlock != null)
        {
            return false;
        }
        if (this.tryBlock != null && !this.tryBlock.Equals(another.tryBlock))
        {
            return false;
        }

        if (this.catches == null && another.catches != null)
        {
            return false;
        }
        if (this.catches != null && !this.catches.SequenceEqual(another.catches))
        {
            return false;
        }

        return true;

    }
}