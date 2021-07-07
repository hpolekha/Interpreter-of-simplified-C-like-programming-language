using Lexer.Token;
using System;
namespace Components
{
    public class FunDefArg : INode
    {
        DataType type;
        string typeEnumName;
        string name;

        public FunDefArg(Token.TokenType type, string name) : this(type, null, name) { }

        public FunDefArg(string typeEnumName, string name) : this(Token.TokenType.T_IDENTIFIER, typeEnumName, name) { }
        private FunDefArg(Token.TokenType type, string typeEnumName, string name)
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
        }

        public string GetFunArgName()
        {
            return name;
        }
        public DataType GetFunDefArgType(){
            return this.type;
        }
        public string GetFunDefArgTypeEnumName(){
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

            FunDefArg another = (FunDefArg)obj;

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