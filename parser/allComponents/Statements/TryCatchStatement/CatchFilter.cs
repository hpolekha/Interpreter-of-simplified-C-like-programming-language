namespace Components
{

    public class CatchFilter : INode
    {
        Expression leftCondition;
        Expression rightCondition;

        public Expression GetLeftCondition()
        {
            return this.leftCondition;
        }
         public Expression GetRightCondition()
        {
            return this.rightCondition;
        }

        public CatchFilter(Expression leftCondition) : this(leftCondition, null) { }
        public CatchFilter(Expression leftCondition, Expression rightCondition)
        {
            this.leftCondition = leftCondition;
            this.rightCondition = rightCondition;
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

            CatchFilter another = (CatchFilter)obj;

            if (this.leftCondition == null && another.leftCondition != null)
            {
                return false;
            }
            if (this.leftCondition != null && !this.leftCondition.Equals(another.leftCondition))
            {
                return false;
            }

            if (this.rightCondition == null && another.rightCondition != null)
            {
                return false;
            }
            if (this.rightCondition != null && !this.rightCondition.Equals(another.rightCondition))
            {
                return false;
            }

            return true;

        }

    }
}