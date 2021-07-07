using Lexer.Token;

namespace Components
{
    public class MultOperator : INode
    {
        public enum Operator
        {
            Multiply,
            Divide,
            Modulo
        }
        Operator multOperator;

        public MultOperator(Token.TokenType multOperator)
        {
            switch (multOperator)
            {
                case Token.TokenType.T_MUL:
                    this.multOperator = Operator.Multiply;
                    break;
                case Token.TokenType.T_DIV:
                    this.multOperator = Operator.Divide;

                    break;
                case Token.TokenType.T_MODULO:
                    this.multOperator = Operator.Modulo;

                    break;
                default:
                    throw new System.ArgumentException();
            }
        }

        public Operator GetMultOperator()
        {
            return this.multOperator;
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

            MultOperator another = (MultOperator)obj;

            if (this.multOperator != another.multOperator)
            {
                return false;
            }

            return true;

        }

    }

}