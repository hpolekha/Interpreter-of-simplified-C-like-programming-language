using System.Collections.Generic;
using System;
using System.Linq;
public class MyProgram
{
    List<EnumDefStatement> enumDefStatements;
    List<FunDefStatement> funDefStatements;

    public MyProgram(List<EnumDefStatement> enumDefStatements, List<FunDefStatement> funDefStatements)
    {
        this.enumDefStatements = enumDefStatements;
        this.funDefStatements = funDefStatements;
        // Console.WriteLine("Program was created");
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

        MyProgram another = (MyProgram)obj;

        if (this.enumDefStatements == null && another.enumDefStatements != null)
        {
            return false;
        }
        if (this.enumDefStatements != null && !this.enumDefStatements.SequenceEqual(another.enumDefStatements))
        {
            return false;
        }

        if (this.funDefStatements == null && another.funDefStatements != null)
        {
            return false;
        }
        if (this.funDefStatements != null && !this.funDefStatements.SequenceEqual(another.funDefStatements))
        {
            return false;
        }

        return true;

    }

}