using System;
using System.Collections.Generic;
using System.Linq;

namespace Components
{

    public class FunCallStatement : Statement, INode
    {
        string name;
        List<Expression> arguments;

        public string GetName()
        {
            return this.name;
        }
        public List<Expression> GetArguments()
        {
            return this.arguments;
        }

        public FunCallStatement(string name, List<Expression> arguments)
        {
            this.name = name;
            this.arguments = arguments;

        }
        public FunCallStatement(string name) : this(name, new List<Expression>())
        {
            this.name = name;
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

            FunCallStatement another = (FunCallStatement)obj;

            if (this.arguments == null && another.arguments != null)
            {
                return false;
            }
            if (this.arguments != null && !this.arguments.SequenceEqual(another.arguments))
            {
                return false;
            }
            if (this.name != another.name)
            {
                return false;
            }

            return true;

        }
    }

}