using System;
using System.Collections.Generic;
using System.Linq;
public class FunCallStatement : Statement
{
    string name;
    List<Condition> arguments;

    public FunCallStatement(string name, List<Condition> arguments)
    {
        this.name = name;
        this.arguments = arguments;

        // Console.WriteLine("FunCallStatement name = " + name);
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

        FunCallStatement another = (FunCallStatement)obj;

        if (this.arguments == null && another.arguments != null)
        {
            return false;
        }
        if (this.arguments != null && !this.arguments.SequenceEqual(another.arguments))
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