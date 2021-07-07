using System;
using Lexer.Token;

namespace Components
{

    public class RelationCondition : Expression, INode
    {
        public enum Operator
        {
            LessThan,
            LessEquals,
            GraterThan,
            GraterEquals,
            Equals,
            NotEquals
        }
        Expression leftPrimaryConditionKay;
        Expression rightPrimaryConditionKay;
        Operator? relationOperator;

        public RelationCondition(Expression leftPrimaryConditionKay)
        {
            this.leftPrimaryConditionKay = leftPrimaryConditionKay;
            this.relationOperator = null;
            this.rightPrimaryConditionKay = null;
        }

        public RelationCondition(Expression leftPrimaryConditionKay, Expression rightPrimaryConditionKay, Token.TokenType relationOperator)
        {
            this.leftPrimaryConditionKay = leftPrimaryConditionKay;
            this.rightPrimaryConditionKay = rightPrimaryConditionKay;
            if(leftPrimaryConditionKay == null || rightPrimaryConditionKay == null)
            {
                throw new System.ArgumentException();
            }
            switch (relationOperator)
            {
                case Token.TokenType.T_LESSEQUALS:
                    this.relationOperator = Operator.LessEquals;
                    break;
                case Token.TokenType.T_LESSTHAN:
                    this.relationOperator = Operator.LessThan;
                    break;
                case Token.TokenType.T_MOREEQUALS:
                    this.relationOperator = Operator.GraterEquals;
                    break;
                case Token.TokenType.T_MORETHAN:
                    this.relationOperator = Operator.GraterThan;
                    break;
                case Token.TokenType.T_EQUALS:
                    this.relationOperator = Operator.Equals;
                    break;
                case Token.TokenType.T_NEQUALS:
                    this.relationOperator = Operator.NotEquals;
                    break;
                default:
                    throw new System.ArgumentException();
            }

        }

        public void accept(INodeVisitor visitor)
        {
            visitor.visit(this);
        }

        public Expression GetLeftPrimaryConditionKay()
        {
            return leftPrimaryConditionKay;

        }

        public bool TryGetRightPrimaryConditionKay(out Expression rightPrimaryConditionKay)
        {
            rightPrimaryConditionKay = null;
            if(this.rightPrimaryConditionKay !=null)
            {
                rightPrimaryConditionKay = this.rightPrimaryConditionKay;
                return true;
            }
            return false;

        }
        public bool TryGetOperator(out Operator? relationOperator)
        {
            relationOperator = null;
            if(this.relationOperator != null)
            {
                relationOperator = this.relationOperator;
                return true;
            }
            return false;
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

            RelationCondition another = (RelationCondition)obj;

            if (this.leftPrimaryConditionKay == null && another.leftPrimaryConditionKay != null)
            {
                return false;
            }
            if (this.leftPrimaryConditionKay != null && !this.leftPrimaryConditionKay.Equals(another.leftPrimaryConditionKay))
            {
                return false;
            }
            if (this.relationOperator == null && another.relationOperator != null)
            {
                return false;
            }
            if (this.relationOperator != null && !this.relationOperator.Equals(another.relationOperator))
            {
                return false;
            }
            if (this.rightPrimaryConditionKay == null && another.rightPrimaryConditionKay != null)
            {
                return false;
            }
            if (this.rightPrimaryConditionKay != null && !this.rightPrimaryConditionKay.Equals(another.rightPrimaryConditionKay))
            {
                return false;
            }


            return true;

        }

    }
}