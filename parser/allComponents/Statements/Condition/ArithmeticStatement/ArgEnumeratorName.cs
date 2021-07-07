namespace Components
{
    public class ArgEnumeratorName : ArithmeticArg, INode
    {
        string parent;
        string child;

        public ArgEnumeratorName(string parent, string child)
        {
            this.parent = parent;
            this.child = child;
        }

        public string GetParent()
        {
            return this.parent;
        }
        public string GetChild()
        {
            return this.child;
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

            ArgEnumeratorName another = (ArgEnumeratorName)obj;

            if (this.parent != another.parent)
            {
                return false;
            }
            if (this.child != another.child)
            {
                return false;
            }

            return true;

        }
    }

}
