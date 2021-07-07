using Lexer.Token;
using System;

namespace Components
{
    public class VarDefInitStatement : Statement, INode
    {
        DataType type;
        string typeEnumName;
        string name;

        Expression condition;

        public VarDefInitStatement(Token.TokenType type, string name)
                            : this(type, null, name, null) { }
        public VarDefInitStatement(Token.TokenType type, string name, Expression condition)
                            : this(type, null, name, condition) { }
        public VarDefInitStatement(string typeEnumName, string name)
                            : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name, null) { }
        public VarDefInitStatement(string typeEnumName, string name, Expression condition)
                            : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name, condition) { }



        public VarDefInitStatement(Token.TokenType type, string typeEnumName, string name, Expression condition)
        {
            switch (type)
            {
                case Token.TokenType.T_INT:
                    this.type = DataType.Integer;
                    break;
                case Token.TokenType.T_STRING:
                    this.type = DataType.String;
                    break;
                case Token.TokenType.T_IDENTIFIER:
                    this.type = DataType.Enum;
                    break;
            }
            this.typeEnumName = typeEnumName;
            this.name = name;
            this.condition = condition;


        }
        public string GetName()
        {
            return this.name;
        }
        public Expression GetExpression()
        {
            return this.condition;
        }

        public DataType GetVarDefInitStatementType()
        {
            return this.type;
        }

        public string GetTypeEnumName(){
            return this.typeEnumName;
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

            VarDefInitStatement another = (VarDefInitStatement)obj;

            if (this.condition == null && another.condition != null)
            {
                return false;
            }
            if (this.condition != null && !this.condition.Equals(another.condition))
            {
                return false;
            }
            if (this.name != another.name)
            {
                return false;
            }
            if (this.typeEnumName != another.typeEnumName)
            {
                return false;
            }

            if (this.type != another.type)
            {
                return false;

            }

            return true;

        }
    }
}