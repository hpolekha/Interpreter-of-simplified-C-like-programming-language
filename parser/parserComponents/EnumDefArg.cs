using System;
public class EnumDefArg
{
    string name;
    ulong? value; // TO DO

    public EnumDefArg(string name, ulong? value)
    {
        this.name = name;
        this.value = value; // TO DO
        // Console.WriteLine("EnumDefArg with name = " + name + " value = " + value);
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