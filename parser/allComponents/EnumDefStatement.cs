using System.Collections.Generic;
using System;
using System.Linq;

namespace Components
{

    public class EnumDefStatement : INode
    {
        string name;
        Dictionary<string, EnumDefArg> enumDefArgs;

        public EnumDefStatement(string name, Dictionary<string, EnumDefArg> enumDefArgs)
        {
            this.name = name;
            this.enumDefArgs = enumDefArgs;
        }

        public string GetEnumName()
        {
            return name;
        }

        public Dictionary<string, EnumDefArg> GetEnumDefArgs()
        {
            return this.enumDefArgs;
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

            EnumDefStatement another = (EnumDefStatement)obj;

            if (this.enumDefArgs == null && another.enumDefArgs != null)
            {
                return false;
            }
            if (this.enumDefArgs != null && !this.enumDefArgs.SequenceEqual(another.enumDefArgs))
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