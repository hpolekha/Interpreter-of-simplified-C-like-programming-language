using System;
using System.Collections.Generic;

namespace Components
{

    public class Catch : INode
    {
        CatchFilter catchFilter;
        Block catchBlock;

        public CatchFilter GetCatchFilter()
        {
            return this.catchFilter;
        }
        public Block GetCatchBlock()
        {
            return this.catchBlock;
        }

        public Catch(CatchFilter catchFilter, Block catchBlock)
        {
            this.catchFilter = catchFilter;
            this.catchBlock = catchBlock;

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

            Catch another = (Catch)obj;

            if (this.catchFilter == null && another.catchFilter != null)
            {
                return false;
            }
            if (this.catchFilter != null && !this.catchFilter.Equals(another.catchFilter))
            {
                return false;
            }

            if (this.catchBlock == null && another.catchBlock != null)
            {
                return false;
            }
            if (this.catchBlock != null && !this.catchBlock.Equals(another.catchBlock))
            {
                return false;
            }

            return true;

        }
    }
}