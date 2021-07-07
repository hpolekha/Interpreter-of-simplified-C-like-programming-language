using System;
namespace Components
{

    public class PrimaryConditionKayArithm : PrimaryConditionKay, Expression, INode
    {
        Expression arithmeticStatement;
        bool ifNegated;
        public PrimaryConditionKayArithm(bool ifNegated, Expression arithmeticStatement)
        {
            this.arithmeticStatement = arithmeticStatement;
            this.ifNegated = ifNegated;
        }

        public Expression GetArithmeticStatement() {
            return this.arithmeticStatement;
         }
        public bool GetIfNegated() { 
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

            PrimaryConditionKayArithm another = (PrimaryConditionKayArithm)obj;

            if (this.arithmeticStatement == null && another.arithmeticStatement != null)
            {
                return false;
            }
            if (this.arithmeticStatement != null && !this.arithmeticStatement.Equals(another.arithmeticStatement))
            {
                return false;
            }

            return true;

        }
    }
}