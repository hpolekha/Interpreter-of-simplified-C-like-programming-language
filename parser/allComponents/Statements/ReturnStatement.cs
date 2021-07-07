using System;

namespace Components
{

    public class ReturnStatement : Statement, INode
    {
        Expression argument;

        public ReturnStatement(Expression argument)
        {
            this.argument = argument;

        }
        public Expression GetArgument()
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

            ReturnStatement another = (ReturnStatement)obj;

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