using System.Collections.Generic;
using System;
using System.Linq;
namespace Components
{
    public class MainProgram : INode
    {
        Dictionary<string, EnumDefStatement> enumDefStatements;
        Dictionary<string, FunDefStatement> funDefStatements;

        public MainProgram(Dictionary<string, EnumDefStatement> enumDefStatements, Dictionary<string, FunDefStatement> funDefStatements)
        {
            this.enumDefStatements = enumDefStatements;
            this.funDefStatements = funDefStatements;
        }

        public void accept(INodeVisitor visitor)
        {
            visitor.visit(this);
        }

        public Dictionary<string, EnumDefStatement> GetEnumDefStatements()
        {
            return this.enumDefStatements;
        }
        public Dictionary<string, FunDefStatement>  GetFunDefStatements()
        {
            return this.funDefStatements;
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

            MainProgram another = (MainProgram)obj;

            if (this.enumDefStatements == null && another.enumDefStatements != null)
            {
                return false;
            }
            if (this.enumDefStatements != null && !this.enumDefStatements.SequenceEqual(another.enumDefStatements))
            {
                return false;
            }

            if (this.funDefStatements == null && another.funDefStatements != null)
            {
                return false;
            }
            if (this.funDefStatements != null && !this.funDefStatements.SequenceEqual(another.funDefStatements))
            {
                return false;
            }

            return true;

        }

    }
}