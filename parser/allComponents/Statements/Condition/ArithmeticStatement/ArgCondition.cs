using System;

namespace Components
{

    public class ArgCondition : ArithmeticArg, INode
    {
        Expression condition;
        bool ifNegated;


        public ArgCondition(Expression condition, bool ifNegated)
        {
            this.condition = condition;
            this.ifNegated = ifNegated;
        }

        public Expression GetCondition()
        {
            return this.condition;
        }

        public bool GetIfNegated()
        {
            return this.ifNegated;
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

            ArgCondition another = (ArgCondition)obj;

            if (this.condition == null && another.condition != null)
            {
                return false;
            }
            if (this.condition != null && !this.condition.Equals(another.condition))
            {
                return false;
            }

            return true;

        }
    }
}