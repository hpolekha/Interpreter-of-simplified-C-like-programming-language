using System.Collections.Generic;
using System.Linq;
using System;
public class ArithmeticStatement
{
    List<AddArg> addArgs;
    public ArithmeticStatement(List<AddArg> addArgs)
    {
        this.addArgs = addArgs;
        // Console.WriteLine("ArithmStatement created");
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

        ArithmeticStatement another = (ArithmeticStatement)obj;

        if (this.addArgs == null && another.addArgs != null)
        {
            return false;
        }
        if (this.addArgs != null && !this.addArgs.SequenceEqual(another.addArgs))
        {
            return false;
        }

        return true;

    }
}