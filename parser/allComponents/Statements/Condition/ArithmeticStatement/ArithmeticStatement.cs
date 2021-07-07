using System.Collections.Generic;
using System.Linq;
using System;

namespace Components
{

    public class ArithmeticStatement : Expression, INode
    {
        List<Expression> addArgs;
        List<AddOperator> addOperators;
        public ArithmeticStatement(List<Expression> addArgs, List<AddOperator> addOperators)
        {
            this.addArgs = addArgs;
            this.addOperators = addOperators;
        }
        public List<Expression> GetAddArgs()
        {
            return this.addArgs;
        }
        public List<AddOperator> GetAddOperators()
        {
            return this.addOperators;
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
}