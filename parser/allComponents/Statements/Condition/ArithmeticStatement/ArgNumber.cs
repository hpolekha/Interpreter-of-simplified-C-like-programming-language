using System;

namespace Components
{

    public class ArgNumber : ArithmeticArg, INode
    {
        ulong number;
        bool ifNegated;

        public ArgNumber(ulong number) : this(number, false) { }
        public ArgNumber(ulong number, bool ifNegated)
        {
            this.number = number;
            this.ifNegated = ifNegated;
        }

        public ulong GetNumber(){
            return this.number;
        }
        public bool GetIfNegated(){
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

            ArgNumber another = (ArgNumber)obj;

            if (this.number != another.number)
            {
                return false;

            }

            return true;

        }
    }
}