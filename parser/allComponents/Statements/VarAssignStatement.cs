using System;

namespace Components
{

    public class VarAssignStatement : Statement, INode
    {
        string name;
        Expression condition;

        public string GetName() {
            return this.name;
        }
        public Expression GetExpression() {
            return this.condition;
        }

        public VarAssignStatement(string name, Expression condition)
        {
            this.name = name;
            this.condition = condition;

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

            VarAssignStatement another = (VarAssignStatement)obj;

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