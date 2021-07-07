using Lexer.Token;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Components
{

    public class AddArg : Expression, INode
    {
        List<Expression> arithmeticArgs;
        List<MultOperator> multOperators;

        public AddArg(List<Expression> arithmeticArgs, List<MultOperator> multOperators)
        {
            this.arithmeticArgs = arithmeticArgs;
            this.multOperators = multOperators;
        }

        public List<Expression> GetArithmeticArgs()
        {
            return this.arithmeticArgs;
        }

        public List<MultOperator> GetMultOperators()
        {
            return this.multOperators;
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

            AddArg another = (AddArg)obj;

            if (this.arithmeticArgs == null && another.arithmeticArgs != null)
            {
                return false;
            }
            if (this.arithmeticArgs != null && !this.arithmeticArgs.SequenceEqual(another.arithmeticArgs))
            {
                return false;
            }

            return true;

        }


    }
}