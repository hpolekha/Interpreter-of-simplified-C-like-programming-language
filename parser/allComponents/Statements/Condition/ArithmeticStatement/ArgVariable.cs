namespace Components
{

    public class ArgVariable : ArithmeticArg, INode
    {
        string varName;
        bool ifNegated;

        public string GetVarName()
        {
            return this.varName;
        }
        public bool GetIfNegated()
        {
            return this.ifNegated;
        }

        public ArgVariable(string varName) : this(varName, false) { }
        public ArgVariable(string varName, bool ifNegated)
        {
            this.varName = varName;
            this.ifNegated = ifNegated;
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

            ArgVariable another = (ArgVariable)obj;

            if (this.varName != another.varName)
            {
                return false;
            }


            return true;

        }
    }
}