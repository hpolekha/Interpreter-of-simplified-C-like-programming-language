namespace Components
{

    public class ArgFunCallStatement : ArithmeticArg, INode
    {
        FunCallStatement funCallStatement;
        bool ifNegated;

        public ArgFunCallStatement(FunCallStatement funCallStatement) : this(funCallStatement, false) { }
        public ArgFunCallStatement(FunCallStatement funCallStatement, bool ifNegated)
        {
            this.funCallStatement = funCallStatement;
            this.ifNegated = ifNegated;
        }

        public bool GetIfNegated()
        {
            return this.ifNegated;
        }

        public FunCallStatement GetFunCallStatement()
        {
            return this.funCallStatement;
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

            ArgFunCallStatement another = (ArgFunCallStatement)obj;

            if (this.funCallStatement == null && another.funCallStatement != null)
            {
                return false;
            }
            if (this.funCallStatement != null && !this.funCallStatement.Equals(another.funCallStatement))
            {
                return false;
            }

            return true;

        }
    }
}