using System.Collections.Generic;
using Components;
using Exceptions;
public class Environment
{
    class CallContext
    {
        List<BlockContext> blockContexts;

        public CallContext()
        {
            this.blockContexts = new List<BlockContext>();
        }

        class BlockContext
        {
            Dictionary<string, Variable> localVariables;

            public BlockContext()
            {
                this.localVariables = new Dictionary<string, Variable>();
            }

            public bool CreateVariable(Variable variable)
            {
                if (localVariables.ContainsKey(variable.GetName()))
                {
                    return false;
                }

                localVariables.Add(variable.GetName(), variable);

                return true;
            }

            public bool DeleteVariable(string name)
            {
                try
                {
                    return localVariables.Remove(name);
                }
                catch (System.ArgumentNullException)
                {
                    return false;
                }
            }

            public Variable GetVariable(string name)
            {
                if (localVariables.TryGetValue(name, out Variable variable))
                {
                    return variable;
                }
                return null;
            }


        }

        public void CreateBlockContext()
        {
            BlockContext newBlockContext = new BlockContext();

            this.blockContexts.Add(newBlockContext);
        }

        public bool DeleteBlockContext()
        {
            if (this.blockContexts.Count < 1 || !DeleteBlockContextAt(this.blockContexts.Count - 1))
            {
                return false;
            }
            return true;
        }

        private bool DeleteBlockContextAt(int index)
        {
            try
            {
                blockContexts.RemoveAt(index);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public bool CreateVariable(Variable variable)
        {
            if (this.blockContexts.Count < 1)
            {
                return false;
            }
            if (FindVariable(variable.GetName(), out Variable v) != null)
            {
                return false;
            }
            return this.blockContexts[this.blockContexts.Count - 1].CreateVariable(variable);

        }

        public bool DeleteVariable(string name)
        {
            BlockContext blockContext;

            if ((blockContext = FindVariable(name, out Variable variable)) != null)
            {
                blockContext.DeleteVariable(name);
                return true;
            }

            return false;
        }

        public Variable GetVariable(string name)
        {
            FindVariable(name, out Variable variable);
            return variable;
        }
        private BlockContext FindVariable(string name, out Variable variable)
        {
            variable = null;
            for (int i = this.blockContexts.Count - 1; i >= 0; i--)
            {
                if ((variable = FindVariableInBlockContext(name, this.blockContexts[i])) != null)
                {
                    return this.blockContexts[i];
                }
            }
            variable = null;
            return null;
        }

        private Variable FindVariableInBlockContext(string name, BlockContext blockContext)
        {
            Variable variable;
            if ((variable = blockContext.GetVariable(name)) != null)
            {
                return variable;
            }
            return null;
        }

    }

    object lastResult;
    DataType lastResultType;
    bool returnFlag;
    public readonly Dictionary<string, FunDefStatement> globalFunctions;
    public readonly Dictionary<string, EnumDefStatement> globalEnums;
    Stack<CallContext> callContexts;
    bool throwFlag;
    ErrnoObject errno;


    public Environment(Dictionary<string, FunDefStatement> globalFunctions, Dictionary<string, EnumDefStatement> globalEnums)
    {
        this.lastResult = null;
        callContexts = new Stack<CallContext>();
        this.globalEnums = globalEnums;
        this.globalFunctions = globalFunctions;
        this.returnFlag = false;
        this.throwFlag = false;
        this.errno = null;
    }
    public bool CreateCallContext()
    {
        CallContext newCallContext = new CallContext();
        this.callContexts.Push(newCallContext);

        if (!newCallContext.Equals(this.callContexts.Peek()))
        {
            return false;
        }

        return true;
    }

    public bool DeleteCallContext()
    {
        try
        {
            this.callContexts.Pop();
        }
        catch (System.InvalidOperationException)
        {
            return false;
        }

        return true;
    }

    public void CreateBlockContext()
    {
        (this.callContexts.Peek()).CreateBlockContext();
    }

    public bool DeleteBlockContext()
    {
        if (this.callContexts.Count < 1)
        {
            return false;
        }
        return (this.callContexts.Peek()).DeleteBlockContext();
    }

    public bool CreateVariable(Variable variable)
    {
        if (variable.GetName() == "errno" && this.errno != null) {
           return false;
        }
        return this.callContexts.Peek().CreateVariable(variable);
    }

    public Variable GetVariable(string name)
    {
        if (name == "errno") {
            if (this.errno == null) {
                return null;
            }
            switch (this.errno.GetDataType()) {
                case DataType.Integer:
                    return new Variable(DataType.Integer, "errno", (long)this.errno.GetValue());
                case DataType.String:
                    return new Variable(DataType.String, "errno", (string)this.errno.GetValue());
                case DataType.Enum:
                    return new Variable(DataType.String, "errno", ((EnumObject)this.errno.GetValue()).getIntValue());
                default:
                    return null;
            }
        }
        return this.callContexts.Peek().GetVariable(name);

    }

    public FunDefStatement GetGlobalFunction(string name)
    {
        if (this.globalFunctions.TryGetValue(name, out FunDefStatement function))
        {
            return function;
        }
        return null;
    }

    public object GetLastResult()
    {
        return lastResult;

    }
    public void SetLastResult(string value)
    {
        this.lastResult = value;
        SetLastResultType(DataType.String);

    }
    public void SetLastResult(long value)
    {
        this.lastResult = value;
        SetLastResultType(DataType.Integer);
    }
    public void SetLastResult(EnumObject value)
    {
        this.lastResult = value;
        SetLastResultType(DataType.Enum);
    }
    public void SetLastResultTypeToVoid()
    {
        this.lastResult = null;
        SetLastResultType(DataType.Void);
    }

    public DataType GetLastResultType()
    {
        return lastResultType;
    }
    private void SetLastResultType(DataType type)
    {
        this.lastResultType = type;
    }

    public bool GetReturnFlag()
    {
        return this.returnFlag;
    }

    public void SetReturnFlag(bool returnFlag)
    {
        this.returnFlag = returnFlag;
    }
    public bool GetThrowFlag()
    {
        return this.throwFlag;
    }

    public void SetThrowFlag(bool throwFlag)
    {
        this.throwFlag = throwFlag;
    }

    public ErrnoObject GetErrno()
    {
        return this.errno;
    }

    public void ResetErrno()
    {
        this.errno = null;
    }
    public void SetErrno() {
        this.errno = new ErrnoObject(this.lastResultType, this.lastResult);
    }

    public bool enumWithIntValueExists(string enumName, long value)
    {
        if (this.globalEnums.TryGetValue(enumName, out EnumDefStatement enumDefStatement))
        {
            foreach (var arg in enumDefStatement.GetEnumDefArgs())
            {
                if ((long)arg.Value.GetValue() == value)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public bool TryGetEnumIntValue(string parent, string name, out long? value)
    {
        value = null;
        if (!this.globalEnums.TryGetValue(parent, out EnumDefStatement enumDefStatement))
        {
            return false;
        }
        if (!enumDefStatement.GetEnumDefArgs().TryGetValue(name, out EnumDefArg v))
        {
            return false;
        }
        value = (long)v.GetValue();
        return true;
    }

    public bool TryGetMinEnumIntValue(string enumName, out long value)
    {
        value = long.MaxValue;
        bool ifFound = false;
        if (!this.globalEnums.TryGetValue(enumName, out EnumDefStatement enumDefStatement))
        {
            return false;
        }

        foreach (var enumDefArg in enumDefStatement.GetEnumDefArgs())
        {
            long tmp = (long)enumDefArg.Value.GetValue();
            if (tmp < value)
            {
                value = tmp;
                ifFound = true;
            }
        }
        return ifFound;
    }

}

public class ErrnoObject
{
    DataType dataType;
    object value;

    public ErrnoObject(DataType dataType, object value)
    {
        this.dataType = dataType;
        this.value = value;
    }

    public void SetAll(DataType dataType, object value)
    {
        this.dataType = dataType;
        this.value = value;
    }

    public DataType GetDataType()
    {
        return this.dataType;
    }

    public object GetValue()
    {
        return this.value;
    }


}

class EnvResult
{

    DataType type;
    object value;

    public EnvResult(DataType type, object value)
    {
        this.type = type;
        this.value = value;
    }

}