using System;

namespace Components
{

    public class IfElseStatement : Statement, INode
    {
        Expression condition;
        Block ifBlock;
        Block elseBlock;

        public IfElseStatement(Expression condition, Block ifBlock, Block elseBlock)
        {
            this.condition = condition;
            this.ifBlock = ifBlock;
            this.elseBlock = elseBlock;

        }

        public Expression GetCondition() {
            return this.condition;
        }

        public Block GetIfBlock() {
            return this.ifBlock;
        }
        public Block GetElseBlock() {
            return this.elseBlock;
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

            IfElseStatement another = (IfElseStatement)obj;

            if (this.condition == null && another.condition != null)
            {
                return false;
            }
            if (this.condition != null && !this.condition.Equals(another.condition))
            {
                return false;
            }
            if (this.ifBlock == null && another.ifBlock != null)
            {
                return false;
            }
            if (this.ifBlock != null && !this.ifBlock.Equals(another.ifBlock))
            {
                return false;
            }
            if (this.elseBlock == null && another.elseBlock != null)
            {
                return false;
            }
            if (this.elseBlock != null && !this.elseBlock.Equals(another.elseBlock))
            {
                return false;
            }

            return true;

        }

    }
}