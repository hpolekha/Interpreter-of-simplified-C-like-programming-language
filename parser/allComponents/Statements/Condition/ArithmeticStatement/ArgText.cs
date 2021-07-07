namespace Components
{

    public class ArgText : ArithmeticArg, INode
    {
        string text;
        public ArgText(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return this.text;
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

            ArgText another = (ArgText)obj;

            if (this.text != another.text)
            {
                return false;
            }

            return true;

        }
    }
}