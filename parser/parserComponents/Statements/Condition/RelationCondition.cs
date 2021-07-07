using System;
using Lexer.Token;
public class RelationCondition
{
    PrimaryConditionKay leftPrimaryConditionKay;
    PrimaryConditionKay rightPrimaryConditionKay;
    Token.TokenType? relationOperator;

    public RelationCondition(PrimaryConditionKay leftPrimaryConditionKay) : this(leftPrimaryConditionKay, null, null) { }

    public RelationCondition(PrimaryConditionKay leftPrimaryConditionKay, PrimaryConditionKay rightPrimaryConditionKay, Token.TokenType? relationOperator)
    {
        this.leftPrimaryConditionKay = leftPrimaryConditionKay;
        this.relationOperator = relationOperator;
        this.rightPrimaryConditionKay = rightPrimaryConditionKay;

        // Console.WriteLine("RelationCondition operator: " + relationOperator.ToString());
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