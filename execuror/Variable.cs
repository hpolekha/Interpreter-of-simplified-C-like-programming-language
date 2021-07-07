public class EnumObject 
{
    string typeEnumName;
    long intValue;
    

    public EnumObject(string typeEnumName, long intValue)
    {
        this.typeEnumName = typeEnumName;
        this.intValue = intValue;
    }
    public long getIntValue()
    {
        return this.intValue;
    }
    public string getTypeEnumName()
    {
        return this.typeEnumName;
        
    }
}




public enum DataType
{
    Enum,
    String,
    Integer,
    Void    

}
public class Variable
{
    protected readonly DataType dataType;

    protected readonly string enumTypeName;
    protected readonly string name;
    object value;

    // Declaration
    public Variable(DataType dataType, string name)
    {
        if (dataType == DataType.Enum)
        {
            throw new System.ArgumentException("Incomplete data type of a variable");
        }
        this.dataType = dataType;
        this.name = name;

        this.enumTypeName = null;
        this.value = null;
    }
    public Variable(string enumTypeName, string name) : this(DataType.Enum, enumTypeName, name, null) { }

    // Declaration with Initialization
    public Variable(DataType dataType, string name, long value) : this(dataType, null, name, value) { }
    public Variable(DataType dataType, string name, string value) : this(dataType, null, name, value) { }
    public Variable(string enumTypeName, string name, long value) : this(DataType.Enum, enumTypeName, name, value) { }

    // General
    private Variable(DataType dataType, string enumTypeName, string name, object value)
    {
        this.dataType = dataType;
        this.enumTypeName = enumTypeName;
        this.name = name;
        this.value = value;
    }

    public DataType GetDataType()
    {
        return this.dataType;
    }

    public string GetEnumTypeName()
    {
        return this.enumTypeName;
    }

    public string GetName()
    {
        return this.name;
    }

    public object GetValue()
    {
        if (this.dataType == DataType.String)
        {
            return (string)this.value;
        }

        return (long)this.value;
    }

    public virtual void SetValue(long value)
    {
        if (this.dataType != DataType.Integer && this.dataType != DataType.Enum)
        {
            throw new System.ArgumentException("Non-convertible type");
        }

        this.value = value;
    }
    public virtual void SetValue(string value)
    {
        if (this.dataType != DataType.String)
        {
            throw new System.ArgumentException("Non-convertible type");
        }
        this.value = value;
    }

    public virtual void SetValue(EnumObject value)
    {
        if (this.dataType != DataType.Enum)
        {
            throw new System.ArgumentException("Non-convertible type");
        }
        if (this.enumTypeName != value.getTypeEnumName()) {
             throw new System.ArgumentException("Non-convertible type"); // different enums
        }
        this.value = value;
    }


}











