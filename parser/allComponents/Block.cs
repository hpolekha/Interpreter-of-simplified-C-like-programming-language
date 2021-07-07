using System;
using System.Collections.Generic;
using System.Linq;

namespace Components
{

    public class Block : INode
    {
        List<Statement> statements;

        public Block(List<Statement> statements)
        {
            this.statements = statements;

        }

        public List<Statement> GetStatements(){
            return this.statements;
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

            Block another = (Block)obj;

            if (this.statements == null && another.statements != null)
            {
                return false;
            }
            if (this.statements != null && !this.statements.SequenceEqual(another.statements))
            {
                return false;
            }

            return true;

        }
    }
}