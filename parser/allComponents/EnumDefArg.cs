using System;

namespace Components
{

    public class EnumDefArg : INode
    {
        string name;
        ulong value;

        public EnumDefArg(string name, ulong value)
        {
            this.name = name;
            this.value = value; 
        }

        public string GetEnumArgName()
        {
            return name;
        }

        public string GetName(){
            return this.name;
        }

        public ulong GetValue()
        {
            return this.value;
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

            EnumDefArg another = (EnumDefArg)obj;

            if (this.value == null && another.value != null)
            {
                return false;
            }
            if (this.value != null && this.value != another.value)
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