using System;
using System.Collections.Generic;
using System.Linq;
public class Condition
{
    List<AndCondition> andConditions;

    public Condition(List<AndCondition> andConditions)
    {
        this.andConditions = andConditions;

        // Console.WriteLine("Condition created");
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

        Condition another = (Condition)obj;

        if (this.andConditions == null && another.andConditions != null)
        {
            return false;
        }
        if (this.andConditions != null && !this.andConditions.SequenceEqual(another.andConditions))
        {
            return false;
        }

        return true;

    }
}