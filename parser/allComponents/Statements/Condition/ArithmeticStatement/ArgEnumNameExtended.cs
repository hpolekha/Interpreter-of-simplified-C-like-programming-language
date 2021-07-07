namespace Components
{

    public class ArgEnumNameExtended : ArithmeticArg, INode
    {
        string parent;
        string name;
        bool ifNegated;

        public ArgEnumNameExtended(string parent, string name) : this(parent, name, false) { }
        public ArgEnumNameExtended(string parent, string name, bool ifNegated)
        {
            this.parent = parent;
            this.name = name;
            this.ifNegated = ifNegated;
        }

        public string GetParent(){
            return this.parent;
        }

        public string GetName()
        {
            return this.name;
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

            ArgEnumNameExtended another = (ArgEnumNameExtended)obj;
            if (this.name != another.name)
            {
                return false;
            }
            if (this.parent != another.parent)
            {
                return false;
            }

            return true;

        }
    }
}