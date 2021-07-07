using System;

namespace Components
{

    public class ThrowStatement : Statement, INode
    {
        Expression argument;

        public ThrowStatement(Expression argument)
        {
            this.argument = argument;

        }

        public Expression getExpression()
        {
            return this.argument;
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

            ThrowStatement another = (ThrowStatement)obj;

            if (this.argument == null && another.argument != null)
            {
                return false;
            }
            if (this.argument != null && !this.argument.Equals(another.argument))
            {
                return false;
            }

            return true;

        }
    }
}