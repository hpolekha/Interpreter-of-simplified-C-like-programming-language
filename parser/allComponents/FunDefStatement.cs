using Lexer.Token;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Components
{
    public class FunDefStatement : INode
    {
        string name;
        DataType returnType;
        string returnTypeEnumName;
        List<Tuple<string, FunDefArg>> funDefArgs;
        Block block;

        public FunDefStatement(Token.TokenType returnType, string name, List<Tuple<string, FunDefArg>> funDefArgs, Block block)
        : this(returnType, null, name, funDefArgs, block) { }
        public FunDefStatement(string returnTypeEnumName, string name, List<Tuple<string, FunDefArg>> funDefArgs, Block block)
        : this(Token.TokenType.T_IDENTIFIER, returnTypeEnumName, name, funDefArgs, block) { }

        public FunDefStatement(Token.TokenType returnType, string returnTypeEnumName, string name, List<Tuple<string, FunDefArg>> funDefArgs, Block block)
        {
            switch (returnType)
            {
                case Token.TokenType.T_INT:
                    this.returnType = DataType.Integer;
                    break;
                case Token.TokenType.T_STRING:
                    this.returnType = DataType.String;
                    break;
                case Token.TokenType.T_IDENTIFIER:
                    this.returnType = DataType.Enum;
                    break;
                case Token.TokenType.T_VOID:
                    this.returnType = DataType.Void;
                    break;
                default:
                    throw new System.ArgumentException();
            }
            this.returnTypeEnumName = returnTypeEnumName;
            this.funDefArgs = funDefArgs;
            this.block = block;
            this.name = name;
        }

        public List<Tuple<string, FunDefArg>> GetFunDefArgs()
        {
            return this.funDefArgs;
        }
        public String GetName()
        {
            return this.name;
        }
        public DataType GetReturnType()
        {
            return this.returnType;
        }
        public Block GetBlock()
        {
            return this.block;
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

            FunDefStatement another = (FunDefStatement)obj;

            if (this.funDefArgs == null && another.funDefArgs != null)
            {
                return false;
            }
            if (this.funDefArgs != null && !this.funDefArgs.SequenceEqual(another.funDefArgs))
            {
                return false;
            }

            if (this.block == null && another.block != null)
            {
                return false;
            }
            if (this.block != null && !this.block.Equals(another.block))
            {
                return false;
            }
            if (this.name != another.name)
            {
                return false;
            }
            if (this.returnTypeEnumName != another.returnTypeEnumName)
            {
                return false;
            }

            if (this.returnType != another.returnType)
            {
                return false;
            }

            return true;

        }
    }
}