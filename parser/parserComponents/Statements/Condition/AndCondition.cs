using System;
using System.Collections.Generic;
using System.Linq;
public class AndCondition
{
    List<RelationCondition> relationConditions;

    public AndCondition(List<RelationCondition> relationConditions)
    {
        this.relationConditions = relationConditions;

        //    Console.WriteLine("AndCondition created");
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

        AndCondition another = (AndCondition)obj;

        if (this.relationConditions == null && another.relationConditions != null)
        {
            return false;
        }
        if (this.relationConditions != null && !this.relationConditions.SequenceEqual(another.relationConditions))
        {
            return false;
        }

        return true;

    }
}