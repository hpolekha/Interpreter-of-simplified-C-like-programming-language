using System;
using System.Collections.Generic;
using System.Linq;

namespace Components
{

    public class Condition : Expression, INode
    {
        List<Expression> andConditions;

        public List<Expression> GetAndConditions() {
            return this.andConditions;
        }

        public Condition(List<Expression> andConditions)
        {
            this.andConditions = andConditions;
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
}