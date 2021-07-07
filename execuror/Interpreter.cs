using Components;
using System.Collections.Generic;
using Lexer.Token;
using System;
using Exceptions;
public class Interpreter0 : INodeVisitor
{
    readonly Environment env;
    readonly MainProgram program;

    public Interpreter0(MainProgram program)
    {
        this.env = new Environment(program.GetFunDefStatements(), program.GetEnumDefStatements());
        this.program = program;
    }
    public void Execute(){
         this.program.accept(this);

        if (env.GetThrowFlag())
        {
            throw new UnhandledUserExceptionLogicException();
        }
    }
    public void visit(MainProgram program)
    {
        Console.WriteLine("Inside Progr " + (env.GetGlobalFunction("main") != null));
        
        FunDefStatement startupFunction;
        if ((startupFunction = env.GetGlobalFunction("main")) != null)
        {
            if (startupFunction.GetReturnType() != DataType.Integer)
            {
                throw new MainReturnTypeLogicException();
            }
            new FunCallStatement(startupFunction.GetName()).accept(this);
        }
    }
    public void visit(FunDefStatement funDefStatement)
    {
        env.CreateCallContext();
        env.CreateBlockContext();
        foreach (var funDefArg in funDefStatement.GetFunDefArgs())
        {
            funDefArg.Item2.accept(this);

        }
        funDefStatement.GetBlock().accept(this);

        DataType funRetType = funDefStatement.GetReturnType();
        if ((funRetType == DataType.Enum || funRetType == DataType.Integer) && env.GetLastResultType() != DataType.Integer)
        {
            throw new IncompatibleDataTypesLogicException();
        }
        else if (funRetType == DataType.String && env.GetLastResultType() != DataType.String)
        {
            throw new IncompatibleDataTypesLogicException();
        }
        env.DeleteBlockContext();
        env.DeleteCallContext();

    }
    public void visit(FunDefArg funDefArg)
    {  }
    public void visit(EnumDefStatement enumDefStatement)
    { }
    public void visit(EnumDefArg enumDefArg)
    { }
    public void visit(Block block)
    {
        System.Console.WriteLine("Inside Block");
        env.CreateBlockContext();
        List<Statement> statements = block.GetStatements();


        for (int i = 0; i < statements.Count && !env.GetReturnFlag() && !env.GetThrowFlag(); i++)
        {
            statements[i].accept(this);
        }
        env.DeleteBlockContext();
    }


    // Statements
    public void visit(VarDefInitStatement varDefInitStatement)
    {
        Console.WriteLine("Inside VarDefIn = " + varDefInitStatement.GetName() + "   " + varDefInitStatement.GetExpression());

        Expression value = varDefInitStatement.GetExpression();
        if (value == null)
        {
            switch (varDefInitStatement.GetVarDefInitStatementType())
            {
                case DataType.Integer:
                    env.SetLastResult(0);
                    break;
                case DataType.String:
                    env.SetLastResult((string)null);
                    break;
                case DataType.Enum:

                    if (env.TryGetMinEnumIntValue(varDefInitStatement.GetTypeEnumName(), out long intValue))
                    {
                        env.SetLastResult(new EnumObject(varDefInitStatement.GetTypeEnumName(), intValue));
                        break;
                    }
                    throw new FaliledDetermineDefaultValueLogicException();
                default:
                    throw new FaliledDetermineDefaultValueLogicException();
            }
        }
        else
        {
            varDefInitStatement.GetExpression().accept(this);
        }


        DataType expectedType = varDefInitStatement.GetVarDefInitStatementType();

        DataType gotType = env.GetLastResultType();

        Variable var;

        switch (expectedType)
        {
            case DataType.Integer:
                if (gotType == DataType.Integer)
                {
                    var = new Variable(DataType.Integer, varDefInitStatement.GetName(), (long)env.GetLastResult());
                }
                else if (gotType == DataType.Enum)
                {
                    var = new Variable(DataType.Integer, varDefInitStatement.GetName(), ((EnumObject)env.GetLastResult()).getIntValue());
                }
                else
                {
                    throw new IncompatibleDataTypesLogicException();
                }
                break;
            case DataType.String:
                if (gotType != DataType.String)
                {
                    throw new IncompatibleDataTypesLogicException();
                }
                var = new Variable(DataType.String, varDefInitStatement.GetName(), (string)env.GetLastResult());
                break;
            case DataType.Enum:
                if (gotType == DataType.Enum)
                {
                    if (!varDefInitStatement.GetTypeEnumName().Equals(((EnumObject)env.GetLastResult()).getTypeEnumName()))
                    {
                        throw new IncompatibleDataTypesLogicException();
                    }
                    var = new Variable(varDefInitStatement.GetTypeEnumName(), varDefInitStatement.GetName(), ((EnumObject)env.GetLastResult()).getIntValue());
                }
                else if (gotType == DataType.Integer)
                {
                    if (!env.enumWithIntValueExists(varDefInitStatement.GetTypeEnumName(), (long)env.GetLastResult()))
                    {
                        throw new IncompatibleDataTypesLogicException();
                    }
                    var = new Variable(varDefInitStatement.GetTypeEnumName(), varDefInitStatement.GetName(), (long)env.GetLastResult());
                }
                else
                {
                    throw new IncompatibleDataTypesLogicException();
                }

                break;
            default:
                throw new IncompatibleDataTypesLogicException();
        }

        Console.WriteLine(env.GetLastResult());
        Variable variable;
        if ((variable = env.GetVariable(varDefInitStatement.GetName())) != null)
        {
            Console.WriteLine(variable.GetName());
            throw new VariableRedeclarationLogicException();
        }
        env.CreateVariable(var);
    }
    public void visit(VarAssignStatement varAssignStatement)
    {
        string varName = varAssignStatement.GetName();
        Variable var = env.GetVariable(varName);
        if (var == null)
        {
            throw new UndefinedVariableLogicException();
        }
        varAssignStatement.GetExpression().accept(this);
        DataType gotType = env.GetLastResultType();

        switch (var.GetDataType())
        {
            case DataType.Integer:
                if (gotType == DataType.Integer)
                {
                    var.SetValue((long)env.GetLastResult());
                }
                else if (gotType == DataType.Enum)
                {
                    var.SetValue(((EnumObject)env.GetLastResult()).getIntValue());
                }
                else
                {
                    throw new IncompatibleDataTypesLogicException();
                }
                break;
            case DataType.String:
                if (gotType != DataType.String)
                {
                    throw new IncompatibleDataTypesLogicException();
                }
                var.SetValue((string)env.GetLastResult());
                break;
            case DataType.Enum:
                if (gotType == DataType.Enum)
                {
                    if (!var.GetEnumTypeName().Equals(((EnumObject)env.GetLastResult()).getTypeEnumName()))
                    {
                        throw new IncompatibleDataTypesLogicException();
                    }
                    var.SetValue(((EnumObject)env.GetLastResult()).getIntValue());
                }
                else if (gotType == DataType.Integer)
                {
                    if (!env.enumWithIntValueExists(var.GetEnumTypeName(), (long)env.GetLastResult()))
                    {
                        throw new IncompatibleDataTypesLogicException();
                    }
                    var.SetValue((long)env.GetLastResult());
                }
                else
                {
                    throw new IncompatibleDataTypesLogicException();
                }
                break;
            default:
                throw new IncompatibleDataTypesLogicException(); 
        }

        Console.WriteLine(env.GetLastResult());

    }
    public void visit(ThrowStatement throwStatement)
    {
        throwStatement.getExpression().accept(this);
        env.SetThrowFlag(true);
    }
    public void visit(ReturnStatement returnStatement)
    {
        Console.WriteLine("Inside ReturnStatement");

        returnStatement.GetArgument().accept(this);

        // Return value already in the lastResult
        env.SetReturnFlag(true);
    }
    public void visit(LoopStatement loopStatement)
    {
        Console.WriteLine("Inside LoopStatement");
        Expression condition = loopStatement.GetCondition();
        Block block = loopStatement.GetBlock();
        condition.accept(this);
        while (isTrue())
        {
            block.accept(this);
            condition.accept(this);
        }
    }
    public void visit(IfElseStatement ifElseStatement)
    {
        Console.WriteLine("Inside IfElseStatement");
        Expression condition = ifElseStatement.GetCondition();
        condition.accept(this);
        if (isTrue())
        {
            ifElseStatement.GetIfBlock().accept(this);
        }
        else
        {
            Block elseBlock = ifElseStatement.GetElseBlock();
            if (elseBlock != null)
            {
                elseBlock.accept(this);
            }
        }
    }
    public void visit(FunCallStatement funCallStatement)
    {
        FunDefStatement funDefStatement = env.GetGlobalFunction(funCallStatement.GetName());
        if (funDefStatement == null)
        {
            throw new UndefinedFunctionCallLogicException();
        }

        List<Tuple<string, FunDefArg>> funDefArgs = funDefStatement.GetFunDefArgs();
        List<Expression> funCallArgs = funCallStatement.GetArguments();
        List<Variable> variables = new List<Variable>();


        if ((funDefArgs != null && funCallArgs == null) || (funDefArgs == null && funCallArgs != null))
        {

            throw new WrongNumberOfArgumentLogicException();
        }

        if (funDefArgs.Count != funCallArgs.Count)
        {
            throw new WrongNumberOfArgumentLogicException();
        }
        if (funDefArgs.Count != 0)
        {
            Variable var;
            DataType gotType;
            for (int i = 0; i < funDefArgs.Count; i++)
            {
                funCallArgs[i].accept(this);

                gotType = env.GetLastResultType();
                switch (funDefArgs[i].Item2.GetFunDefArgType())
                {
                    case DataType.Integer:
                        if (gotType == DataType.Integer)
                        {
                            var = new Variable(DataType.Integer, funDefArgs[i].Item1, (long)env.GetLastResult());
                        }
                        else if (gotType == DataType.Enum)
                        {
                            var = new Variable(DataType.Integer, funDefArgs[i].Item1, ((EnumObject)env.GetLastResult()).getIntValue());
                        }
                        else
                        {
                            throw new IncompatibleDataTypesLogicException();
                        }
                        break;
                    case DataType.String:
                        if (gotType != DataType.String)
                        {
                            throw new IncompatibleDataTypesLogicException();
                        }
                        var = new Variable(DataType.String, funDefArgs[i].Item1, (string)env.GetLastResult());
                        break;
                    case DataType.Enum:
                        if (gotType == DataType.Enum)
                        {
                            if (!funDefArgs[i].Item2.GetFunDefArgTypeEnumName().Equals(((EnumObject)env.GetLastResult()).getTypeEnumName()))
                            {
                                throw new IncompatibleDataTypesLogicException();
                            }
                            var = new Variable(funDefArgs[i].Item2.GetFunDefArgTypeEnumName(), funDefArgs[i].Item1, ((EnumObject)env.GetLastResult()).getIntValue());
                        }
                        else if (gotType == DataType.Integer)
                        {
                            if (!env.enumWithIntValueExists(funDefArgs[i].Item2.GetFunDefArgTypeEnumName(), (long)env.GetLastResult()))
                            {
                                throw new IncompatibleDataTypesLogicException();
                            }
                            var = new Variable(funDefArgs[i].Item2.GetFunDefArgTypeEnumName(), funDefArgs[i].Item1, (long)env.GetLastResult());
                        }
                        else
                        {
                            throw new IncompatibleDataTypesLogicException();
                        }

                        break;
                    default:
                        throw new IncompatibleDataTypesLogicException();
                }
                variables.Add(var);
            }
        }

        env.CreateCallContext();
        env.CreateBlockContext();

        foreach (Variable v in variables)
        {
            env.CreateVariable(v);
        }

        funDefStatement.GetBlock().accept(this);

        if (env.GetThrowFlag())
        {
            env.DeleteCallContext();
            return;
        }

        if (funDefStatement.GetReturnType() == DataType.Void)
        {
            env.SetLastResultTypeToVoid();
        }
        if (!env.GetReturnFlag())
        {
            throw new ReturnValueNotFoundLogicException();
        }
        if (funDefStatement.GetReturnType() != env.GetLastResultType())
        {
            throw new IncompatibleDataTypesLogicException();
        }

        env.SetReturnFlag(false);

        env.DeleteCallContext();
    }

    // TryCatchStatement
    public void visit(TryCatchStatement tryCatchStatement)
    {

        tryCatchStatement.GetTryBlock().accept(this);
        if (env.GetThrowFlag())
        {
            DataType dataType = this.env.GetLastResultType();
            object lastResult = this.env.GetLastResult();
            List<Catch> catches = tryCatchStatement.GetCatches();
            foreach (Catch c in catches)
            {
                c.accept(this);
                if (!env.GetThrowFlag())
                {
                    return;
                }
            }
        }
    }
    public void visit(CatchFilter catchFilter)
    {

        // if filter matches then set thow flag to false
        Console.WriteLine(catchFilter.GetLeftCondition().GetType());

        DataType dataType = env.GetLastResultType();
        object value = env.GetLastResult();

        catchFilter.GetLeftCondition().accept(this);

        if (catchFilter.GetRightCondition() == null)
        {

            if (dataType == DataType.String &&
                env.GetLastResultType() == DataType.String &&
                (string)value == (string)env.GetLastResult())
            {
                env.SetThrowFlag(false);
                return;
            }

            if (dataType == DataType.Integer)
            {
                if (env.GetLastResultType() == DataType.Integer &&
                (long)value == (long)env.GetLastResult())
                {
                    env.SetThrowFlag(false);
                    return;
                }
                else if (env.GetLastResultType() == DataType.Enum &&
                  (long)value == ((EnumObject)env.GetLastResult()).getIntValue())
                {
                    env.SetThrowFlag(false);
                    return;
                }
            }

            if (dataType == DataType.Enum)
            {
                if (env.GetLastResultType() == DataType.Enum &&
                ((EnumObject)value).getTypeEnumName() == ((EnumObject)env.GetLastResult()).getTypeEnumName() &&
                 ((EnumObject)value).getIntValue() == ((EnumObject)env.GetLastResult()).getIntValue())
                {
                    env.SetThrowFlag(false);
                    return;
                }
                else if (env.GetLastResultType() == DataType.Integer &&
                 ((EnumObject)value).getIntValue() == (long)env.GetLastResult())
                {
                    env.SetThrowFlag(false);
                    return;
                }
            }

        }
        else
        {
            DataType leftType = env.GetLastResultType();
            object leftValue = env.GetLastResult();

            catchFilter.GetRightCondition().accept(this);


            long leftLong = long.MaxValue;
            long rightLong = long.MinValue;
            if (leftType == DataType.Integer)
            {
                leftLong = (long)leftValue;
            }
            else if (dataType == DataType.Enum)
            {
                leftLong = ((EnumObject)leftValue).getIntValue();
            }
            if (env.GetLastResultType() == DataType.Integer)
            {
                rightLong = (long)env.GetLastResult();
            }
            else if (env.GetLastResultType() == DataType.Enum)
            {
                rightLong = ((EnumObject)env.GetLastResult()).getIntValue();
            }
            if (dataType == DataType.Integer)
            {
                if ((long)value >= leftLong && (long)value <= rightLong)
                {
                    env.SetThrowFlag(false);
                    return;
                }
            }
            else if (dataType == DataType.Enum)
            {
                if (((EnumObject)value).getIntValue() >= leftLong && ((EnumObject)value).getIntValue() <= rightLong)
                {
                    env.SetThrowFlag(false);
                    return;
                }
            }


        }
        switch (dataType)
        {
            case DataType.Integer:
                this.env.SetLastResult((long)value);
                break;
            case DataType.Enum:
                this.env.SetLastResult((EnumObject)value);
                break;
            case DataType.String:
                this.env.SetLastResult((string)value);
                break;
            default:
                break;
        }

    }
    public void visit(Catch c)
    {
        c.GetCatchFilter().accept(this);
        if (!this.env.GetThrowFlag())
        {
            env.SetErrno();
            c.GetCatchBlock().accept(this);
            env.ResetErrno();
            return;
        }
    }

    // Condition
    public void visit(RelationCondition relationCondition)
    {
        Console.WriteLine("Inside RelationCond");

        relationCondition.GetLeftPrimaryConditionKay().accept(this);
        if (env.GetLastResultType() == DataType.String)
        {
            string leftResult = (string)env.GetLastResult();
            if (stringComparison(relationCondition, leftResult, out int lastResult))
            {
                env.SetLastResult(lastResult);
                return;
            }
            env.SetLastResult(leftResult);
            return;
        }


        RelationCondition.Operator? relationOperator;
        if (!relationCondition.TryGetOperator(out relationOperator))
        {
            // LeftPrimaryConditionKay result stays in the env.lastValue
            return;
        }

        long leftIntResult;

        if (env.GetLastResultType() == DataType.Integer)// && env.GetLastResultType() == DataType.Enum)
        {
            leftIntResult = (long)env.GetLastResult();
        }
        else if (env.GetLastResultType() == DataType.Enum)
        {
            leftIntResult = ((EnumObject)env.GetLastResult()).getIntValue();
        }
        else
        {
            throw new IncompatibleDataTypesLogicException();
        }

        Expression rightPrimaryContitionKey;
        if (!relationCondition.TryGetRightPrimaryConditionKay(out rightPrimaryContitionKey))
        {
            throw new UndefinedExpressionLogicException();
        }
        rightPrimaryContitionKey.accept(this);

        long rightIntResult;

        if (env.GetLastResultType() == DataType.Integer)
        {
            rightIntResult = (long)env.GetLastResult();
        }
        else if (env.GetLastResultType() == DataType.Enum)
        {
            rightIntResult = ((EnumObject)env.GetLastResult()).getIntValue();
        }
        else
        {
            throw new IncompatibleDataTypesLogicException();
        }

        long result;
        switch (relationOperator)
        {
            case RelationCondition.Operator.LessThan:
                if (leftIntResult < rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            case RelationCondition.Operator.LessEquals:
                if (leftIntResult <= rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            case RelationCondition.Operator.GraterThan:
                if (leftIntResult > rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            case RelationCondition.Operator.GraterEquals:
                if (leftIntResult >= rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            case RelationCondition.Operator.Equals:
                if (leftIntResult == rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            case RelationCondition.Operator.NotEquals:
                if (leftIntResult != rightIntResult)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                break;
            default:
                throw new UndefinedOperatorLogicException();
        }

        env.SetLastResult(result);


    }

    private bool stringComparison(RelationCondition relationCondition, string leftResult, out int lastResult)
    {
        lastResult = 0;

        RelationCondition.Operator? relationOperator;
        if (!relationCondition.TryGetOperator(out relationOperator))
        {
            return false;
        }
        RelationCondition.Operator relOperator = (RelationCondition.Operator)relationOperator;

        Expression rightPrimaryContitionKey;
        if (!relationCondition.TryGetRightPrimaryConditionKay(out rightPrimaryContitionKey))
        {
            throw new UndefinedExpressionLogicException();
        }
        rightPrimaryContitionKey.accept(this);
        if (env.GetLastResultType() != DataType.String)
        {
            throw new IncompatibleDataTypesLogicException();
        }


        string rightResult = (string)env.GetLastResult();

        if (relOperator == RelationCondition.Operator.Equals)
        {
            if (leftResult.Equals(rightResult))
            {
                lastResult = 1;
            }
            else
            {
                lastResult = 0;
            }
            return true;

        }
        else if (relOperator == RelationCondition.Operator.NotEquals)
        {
            if (leftResult.Equals(rightResult))
            {
                lastResult = 1;
            }
            else
            {
                lastResult = 0;
            }
            return true;
        }

        throw new InvalidOperationException();
    }

    public void visit(PrimaryConditionKayArithm primaryConditionKayArithm)
    {
        Console.WriteLine("Inside PrimaryCondotoin");

        primaryConditionKayArithm.GetArithmeticStatement().accept(this);

        DataType resType = env.GetLastResultType();

        if (!primaryConditionKayArithm.GetIfNegated())
        {
            // No convertion to 1/0
            if (resType != DataType.Integer && resType != DataType.Enum && resType != DataType.String)
            {
                throw new IncompatibleDataTypesLogicException();
            }
            return;
        }

        // Negated
        long result;
        if (resType == DataType.Enum)
        {
            result = ((EnumObject)env.GetLastResult()).getIntValue();
        }
        else if (resType == DataType.Integer)
        {
            result = (long)env.GetLastResult();
        }
        else
        {
            // type is not compatible with ! operator
            throw new IncompatibleDataTypesLogicException(); 
        }

        if (result == 0)
        {
            env.SetLastResult(1);
            return;
        }
        env.SetLastResult(0);

    }

    public void visit(Condition condition)
    {
        Console.WriteLine("Inside Condition");

        List<Expression> andConditions = condition.GetAndConditions();

        foreach (Expression expression in andConditions)
        {
            expression.accept(this);
            if (isTrue())
            {
                this.env.SetLastResult(1);
                return;
            }
        }
        this.env.SetLastResult(0);
    }

    private bool isTrue()
    {
        if (this.env.GetLastResult() == null)
        {
            return false;
        }
        if (this.env.GetLastResultType() == DataType.Integer)
        {
            return (long)this.env.GetLastResult() != 0;
        }
        if (this.env.GetLastResultType() == DataType.Enum)
        {
            return ((EnumObject)this.env.GetLastResult()).getIntValue() != 0;
        }
        if (this.env.GetLastResultType() == DataType.String)
        {
            return true;
        }
        throw new IncompatibleDataTypesLogicException();
    }
    public void visit(AndCondition andCondition)
    {
        Console.WriteLine("Inside AndCond");

        List<Expression> relationConditions = andCondition.GetRelationCondition();

        foreach (Expression expression in relationConditions)
        {
            expression.accept(this);
            if (!isTrue())
            {
                this.env.SetLastResult(0);
                return;
            }
        }


        this.env.SetLastResult(1);
    }

    // ArithmeticStatement

    public void visit(ArgCondition argCondition)
    {
        argCondition.GetCondition().accept(this);
        long result = (long)env.GetLastResult(); 
        if (argCondition.GetIfNegated())
        {
            result *= -1;
        }
        env.SetLastResult(result);
    }
    public void visit(ArgVariable argVariable)
    {
        Variable var = env.GetVariable(argVariable.GetVarName());
        if (var == null)
        {
            throw new UndefinedVariableLogicException();
        }

        switch (var.GetDataType())
        {
            case DataType.Integer:
                long valInt = (long)var.GetValue();
                if (argVariable.GetIfNegated())
                {
                    valInt *= -1;
                }
                env.SetLastResult(valInt);
                break;
            case DataType.String:
                string valStr = (string)var.GetValue();
                if (argVariable.GetIfNegated())
                {
                    throw new InvalidOperationLogicException();
                }
                env.SetLastResult(valStr);
                break;
            case DataType.Enum:
                long val = (long)var.GetValue();
                if (argVariable.GetIfNegated())
                {
                    val *= -1;
                }
                env.SetLastResult(val);
                break;
            default:
                throw new IncompatibleDataTypesLogicException();
        }


    }
    public void visit(ArgText argText)
    {
        Console.WriteLine("Inside ArgText");

        string text = argText.GetText();
        env.SetLastResult(text);
    }
    public void visit(ArgNumber argNumber)
    {
        Console.WriteLine("Inside ArgNum");

        long number = (long)argNumber.GetNumber();
        if (argNumber.GetIfNegated())
        {
            number *= -1;
        }
        env.SetLastResult(number);
    }
    public void visit(ArgFunCallStatement argFunCallStatement)
    {
        Console.WriteLine("Inside ArgEnumNameExtended");
        argFunCallStatement.GetFunCallStatement().accept(this);
        if (argFunCallStatement.GetIfNegated())
        {
            if (env.GetLastResultType() == DataType.Integer || env.GetLastResultType() == DataType.Enum)
            {
                long result = (long)env.GetLastResult();
                result *= -1;
                env.SetLastResult(result);
            }
            else
            {
                throw new InvalidOperationLogicException();
            }
        }
    }
    public void visit(ArgEnumNameExtended argEnumNameExtended) 
    {
        Console.WriteLine("Inside ArgEnumNameExtended");

        if (!env.TryGetEnumIntValue(argEnumNameExtended.GetParent(), argEnumNameExtended.GetName(), out long? value))
        {
            throw new UndefineEnumeratorLogicException();
        }

        if (argEnumNameExtended.GetIfNegated())
        {
            value *= -1;
        }
        env.SetLastResult(new EnumObject(argEnumNameExtended.GetParent(), (long)value));
    }
    public void visit(ArgEnumeratorName argEnumeratorName)
    {
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.Inside ArgEnumeratorName");
        if (!env.TryGetEnumIntValue(argEnumeratorName.GetParent(), argEnumeratorName.GetChild(), out long? value))
        {
            throw new UndefineEnumeratorLogicException();
        }
        env.SetLastResult(argEnumeratorName.GetParent() + "." + argEnumeratorName.GetChild());
    }
    public void visit(ArgEnumeratorValue argEnumeratorValue)
    {
        Console.WriteLine("Inside ArgEnumeratorValue");
        if (!env.TryGetEnumIntValue(argEnumeratorValue.GetParent(), argEnumeratorValue.GetChild(), out long? value))
        {
            throw new UndefineEnumeratorLogicException();
        }
        long result = (long)value;
        if (argEnumeratorValue.GetIfNegated())
        {
            result *= -1;
        }
        env.SetLastResult(result);

    }
    public void visit(ArithmeticStatement arithmeticStatement)
    {
        Console.WriteLine("Inside Arithmertic statement");

        List<Expression> addArgs = arithmeticStatement.GetAddArgs();
        List<AddOperator> addOperators = arithmeticStatement.GetAddOperators();

        addArgs[0].accept(this);

        DataType lastResType = env.GetLastResultType();

        // Concatination
        if (lastResType == DataType.String)
        {
            if (TryConcat(addArgs, (string)env.GetLastResult(), addOperators, out string concatResult))
            {
                env.SetLastResult(concatResult);
                return;
            }
            else
            {
                new InvalidOperationLogicException();
            }
        }

        // Math
        long result;
        if (env.GetLastResultType() == DataType.Integer)
        {
            result = (long)env.GetLastResult();
        }
        else if (env.GetLastResultType() == DataType.Enum)
        {
            result = ((EnumObject)env.GetLastResult()).getIntValue();
        }
        else
        {
            throw new IncompatibleDataTypesLogicException();
        }

        for (int i = 1; i < addArgs.Count; i++)
        {
            addArgs[i].accept(this);

            long nextArg;
            if (env.GetLastResultType() == DataType.Integer)
            {
                nextArg = (long)env.GetLastResult();
            }
            else if (env.GetLastResultType() == DataType.Enum)
            {
                nextArg = ((EnumObject)env.GetLastResult()).getIntValue();
            }
            else
            {
                throw new IncompatibleDataTypesLogicException();
            }

            if (addOperators[i - 1].GetAddOperator() == AddOperator.Operator.Plus)
            {
                result += nextArg;
            }
            else if (addOperators[i - 1].GetAddOperator() == AddOperator.Operator.Minus)
            {
                result -= nextArg;
            }
            else
            {
                throw new UndefinedOperatorLogicException();
            }
        }

        env.SetLastResult(result);

    }
    private bool TryConcat(List<Expression> args, string firstArg, List<AddOperator> operators, out string result)
    {
        result = firstArg;
        for (int i = 1; i < args.Count; i++)
        {
            args[i].accept(this);
            string nextArg;
            if (env.GetLastResultType() != DataType.String || operators[i - 1].GetAddOperator() != AddOperator.Operator.Plus)
            {
                return false;
            }
            nextArg = (string)env.GetLastResult();
            result += nextArg;
        }

        env.SetLastResult(result);
        Console.WriteLine("concRes = " + result);
        return true;
    }
    public void visit(AddArg addArg)
    {
        Console.WriteLine("Inside AddArg");

        List<Expression> arithmeticArgs = addArg.GetArithmeticArgs();
        List<MultOperator> multOperators = addArg.GetMultOperators();

        arithmeticArgs[0].accept(this);

        long result;

        if (env.GetLastResultType() == DataType.Integer)
        {
            result = (long)env.GetLastResult();
        }
        else if (env.GetLastResultType() == DataType.Enum)
        {
            result = ((EnumObject)env.GetLastResult()).getIntValue();
        }
        else
        {
            throw new IncompatibleDataTypesLogicException();
        }


        for (int i = 1; i < arithmeticArgs.Count; i++)
        {
            arithmeticArgs[i].accept(this);

            long nextArg;
            if (env.GetLastResultType() == DataType.Integer)
            {
                nextArg = (long)env.GetLastResult();
            }
            else if (env.GetLastResultType() == DataType.Enum)
            {
                nextArg = ((EnumObject)env.GetLastResult()).getIntValue();
            }
            else
            {
                throw new IncompatibleDataTypesLogicException();
            }

            if (multOperators[i - 1].GetMultOperator() == MultOperator.Operator.Multiply)
            {
                result *= nextArg;
            }
            else
            {
                if (nextArg == 0)
                {
                    throw new DvivisionByZeroLogicException();
                }

                if (multOperators[i - 1].GetMultOperator() == MultOperator.Operator.Divide)
                {
                    result /= nextArg;
                }
                else if (multOperators[i - 1].GetMultOperator() == MultOperator.Operator.Modulo)
                {
                    result %= nextArg;
                }
                else
                {
                    throw new UndefinedOperatorLogicException();
                }
            }

        }
        env.SetLastResult(result);
    }
    public void visit(AddOperator addOperator)
    { }
    public void visit(MultOperator multOperator)
    { }



}