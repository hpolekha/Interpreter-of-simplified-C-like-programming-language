using System;
using System.Collections.Generic;
using System.Linq;

namespace Components
{

    public class AndCondition : Expression, INode
    {
        List<Expression> relationConditions;

        public AndCondition(List<Expression> relationConditions)
        {
            this.relationConditions = relationConditions;

        }

        public List<Expression> GetRelationCondition()
        {
            return this.relationConditions;
        }

        public void accept(INodeVisitor visitor)
        {
            visitor.visit(this);
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

}