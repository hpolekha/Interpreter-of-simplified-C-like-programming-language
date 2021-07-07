using Lexer.Token;

namespace Components
{
    public class AddOperator : INode
    {
        public enum Operator
        {
            Plus,
            Minus
        }
        Operator addOperator;

        public AddOperator(Token.TokenType addOperator)
        {
            if (addOperator == Token.TokenType.T_PLUS)
            {
                this.addOperator = Operator.Plus;
            }
            else if (addOperator == Token.TokenType.T_MINUS)
            {
                this.addOperator = Operator.Minus;
            }
            else
            {
                throw new System.ArgumentException();
            }
        }

        public Operator GetAddOperator()
        {
            return this.addOperator;
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

            AddOperator another = (AddOperator)obj;

            if (this.addOperator != another.addOperator)
            {
                return false;
            }

            return true;

        }



    }

}