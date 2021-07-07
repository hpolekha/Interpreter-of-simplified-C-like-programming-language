using System.Collections.Generic;
using System;
using System.Linq;
public class EnumDefStatement
{
    string name;
    List<EnumDefArg> enumDefArgs;

    public EnumDefStatement(string name, List<EnumDefArg> enumDefArgs)
    {
        this.name = name;
        this.enumDefArgs = enumDefArgs;
        // Console.WriteLine("EnumDefStatement with name = " + name);
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

        EnumDefStatement another = (EnumDefStatement)obj;

        if (this.enumDefArgs == null && another.enumDefArgs != null)
        {
            return false;
        }
        if (this.enumDefArgs != null && !this.enumDefArgs.SequenceEqual(another.enumDefArgs))
        {
            return false;
        }
        if (this.name != another.name)
        {
            return false;
        }

        return true;

    }

}