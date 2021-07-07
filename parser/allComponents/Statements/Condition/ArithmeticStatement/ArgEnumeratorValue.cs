namespace Components
{
    public class ArgEnumeratorValue : ArithmeticArg, INode
    {
        string parent;
        string child;
        bool ifNegated;

        public ArgEnumeratorValue(string parent, string child, bool ifNegated)
        {
            this.parent = parent;
            this.child = child;
            this.ifNegated = ifNegated;
        }

        public string GetParent()
        {
            return this.parent;
        }
        public string GetChild()
        {
            return this.child;
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

            ArgEnumeratorValue another = (ArgEnumeratorValue)obj;

            if (this.parent != another.parent)
            {
                return false;
            }
            if (this.child != another.child)
            {
                return false;
            }
            if (this.ifNegated != another.ifNegated)
            {
                return false;
            }
            return true;

        }
    }

}
