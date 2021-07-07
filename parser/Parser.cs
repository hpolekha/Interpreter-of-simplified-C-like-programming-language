using Lexer.Scanner;
using Lexer.Token;
using System.Collections.Generic;
using Components;
using Exceptions;
using System;
public class Parser
{
    Scanner scanner;
    Token current;

    public Parser(Scanner scanner)
    {
        this.scanner = scanner;
        this.current = scanner.GetNextToken();
    }

    public MainProgram ParseProgram()
    {
        // Parse definition statements
        Dictionary<string, EnumDefStatement> enumDefStatements = new Dictionary<string, EnumDefStatement>();
        Dictionary<string, FunDefStatement> funDefStatements = new Dictionary<string, FunDefStatement>();


        while (ParseOneDefStatement(enumDefStatements, funDefStatements)) { }

        // Check if the end of source is reached
        if (this.current.GetType() != Token.TokenType.T_END)
        {
            throw new UnknownDefinitionStatement(this.current.GetLine(), this.current.GetPosition());
        }

        // Create a program
        return new MainProgram(enumDefStatements, funDefStatements);
    }
    public bool ParseOneDefStatement(Dictionary<string, EnumDefStatement> enumDefStatements, Dictionary<string, FunDefStatement> funDefStatements)
    {
        EnumDefStatement enumDefStatement;
        FunDefStatement funDefStatement;

        if ((enumDefStatement = TryParseEnumDefStatement()) != null)
        {
            // Create enum definition statements
            if (enumDefStatements.ContainsKey(enumDefStatement.GetEnumName()))
            {
                throw new MultipleEnumDefinitionException(current.GetLine(), current.GetPosition());
            }
            enumDefStatements.Add(enumDefStatement.GetEnumName(), enumDefStatement);
            return true;
        }

        if ((funDefStatement = TryParseFunDefStatement()) != null)
        {
            // Create function definition statement
            if (funDefStatements.ContainsKey(funDefStatement.GetName()))
            {
                throw new MultipleFunctionDefinitionException(current.GetLine(), current.GetPosition());
            }
            funDefStatements.Add(funDefStatement.GetName(), funDefStatement);
            return true;
        }

        return false;

    }
    void f(int a) { }
    void advance()
    {
        this.current = scanner.GetNextToken();
    }
    bool currentTypeIs(Token.TokenType type)
    {
        return this.current.GetType() == type;
    }

    EnumDefStatement TryParseEnumDefStatement()
    {
        // Keyword "enum"
        if (!currentTypeIs(Token.TokenType.T_ENUM))
        {
            return null;
        }
        advance();

        // Enum's name
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            throw new IdentifierExpectedEnumDefinitionException(current.GetLine(), current.GetPosition());
        }

        string enumName = current.GetValue().ToString();
        advance();

        // Opening "{"
        if (!currentTypeIs(Token.TokenType.T_LBRACE))
        {
            throw new OpeningBraceExpectedException(this.current.GetLine(), this.current.GetPosition());
        }

        // Enum's fields
        Dictionary<string, EnumDefArg> enumDefArgs = new Dictionary<string, EnumDefArg>();
        do
        {
            advance();
            EnumDefArg enumDefArg = TryParseEnumDefArg();
            if (enumDefArg == null)
            {
                throw new EnumeratorListUnfinshedEnumDefinitionException(current.GetLine(), current.GetPosition());
            }

            if (enumDefArgs.ContainsKey(enumDefArg.GetEnumArgName()))
            {
                throw new EnumeratorRedefinitionEnumDefinitionException(current.GetLine(), current.GetPosition());
            }
            enumDefArgs.Add(enumDefArg.GetEnumArgName(), enumDefArg);

        } while (currentTypeIs(Token.TokenType.T_COMMA));

        // Closing "}"
        CurrentTypeMustBe(Token.TokenType.T_RBRACE, new ClosingBraceExpectedException(this.current.GetLine(), this.current.GetPosition()));


        return new EnumDefStatement(enumName, enumDefArgs);
    }

    EnumDefArg TryParseEnumDefArg()
    {
        // Field's name
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            return null;
        }
        string name = this.current.GetValue().ToString();

        advance();

        // Field's value
        ulong value = 0;
        if (currentTypeIs(Token.TokenType.T_ASSIGN))
        {
            advance();
            if (!currentTypeIs(Token.TokenType.T_INTCONST))
            {
                throw new EnumeratorInitializerExpectedEnumDefinitionException(current.GetLine(), current.GetPosition());
            }
            value = (ulong)this.current.GetValue();
            advance();
        }

        return new EnumDefArg(name, value);
    }

    FunDefStatement TryParseFunDefStatement()
    {
        // Return type
        if (!currentTypeIs(Token.TokenType.T_VOID) && !currentIsDataType()) // !int && !string && !idetifier
        {
            return null;
        }
        Token.TokenType returnType = this.current.GetType();

        string funName = null;
        //Dictionary<string, FunDefArg> funDefArgs = null;
        List<Tuple<string, FunDefArg>> funDefArgs = null;
        Block block = null;


        if (returnType == Token.TokenType.T_IDENTIFIER)
        {
            string returnTypeEnumName = this.current.GetValue().ToString();
            advance();

            ParseFunNameArgsBlock(out funName, out funDefArgs, out block);

            return new FunDefStatement(returnTypeEnumName, funName, funDefArgs, block);

        }

        advance();

        ParseFunNameArgsBlock(out funName, out funDefArgs, out block);

        return new FunDefStatement(returnType, funName, funDefArgs, block);
    }

    void ParseFunNameArgsBlock(out string name, out List<Tuple<string, FunDefArg>> funDefArgs, out Block block)
    {
        // Function's name
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            throw new IdentifierExpectedFunctionDefinitionException(current.GetLine(), current.GetPosition());
        }
        name = this.current.GetValue().ToString();
        advance();

        // Opening "("
        CurrentTypeMustBe(Token.TokenType.T_LPARENT, new OpeningParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));

        // Function's parameters
        funDefArgs = new List<Tuple<string, FunDefArg>>();
        FunDefArg funDefArg = null;
        funDefArg = TryParseFunDefArg();
        if (funDefArg != null)
        {
            funDefArgs.Add(new Tuple<string, FunDefArg>(funDefArg.GetFunArgName(), funDefArg));
            while (currentTypeIs(Token.TokenType.T_COMMA))
            {
                advance();
                funDefArg = TryParseFunDefArg();
                if (funDefArg == null)
                {
                    throw new ParameterExpectedFunctionDefinitionException(current.GetLine(), current.GetPosition());

                }

                foreach (var funArg in funDefArgs)
                {
                    if (funArg.Item1 == funDefArg.GetFunArgName())
                    {
                        throw new ParameterRedefinitionFunctionDefinitionException(current.GetLine(), current.GetPosition());
                    }
                }
                funDefArgs.Add(new Tuple<string, FunDefArg>(funDefArg.GetFunArgName(), funDefArg)); 
            }
        }

        // Closing ")"
        CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // Block
        block = TryParseBlock();
        if (block == null)
        {
            throw new FunctionBodyExpectedFunctionDefinitionException(current.GetLine(), current.GetPosition());
        }
    }
    
    bool currentIsDataType()
    {
        return currentTypeIs(Token.TokenType.T_INT)
            || currentTypeIs(Token.TokenType.T_STRING)
            || currentTypeIs(Token.TokenType.T_IDENTIFIER);
    }
    FunDefArg TryParseFunDefArg()
    {
        if (currentTypeIs(Token.TokenType.T_INT) || currentTypeIs(Token.TokenType.T_STRING))
        {
            // Data type
            Token.TokenType type = this.current.GetType();
            advance();

            // Parameter's name
            string name = TryParseParameterName();
            if (name == null)
            {
                throw new IdentifierExpectedFunctionDefinitionException(current.GetLine(), current.GetPosition());
            }
            return new FunDefArg(type, name);

        }
        else if (currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            // Data type
            string typeEnumName = this.current.GetValue().ToString();
            advance();

            // Parameter's name
            string name = TryParseParameterName();
            if (name == null)
            {
                throw new IdentifierExpectedFunctionDefinitionException(current.GetLine(), current.GetPosition());

            }
            return new FunDefArg(typeEnumName, name);
        }
        return null;
    }
    string TryParseParameterName()
    {
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            return null;
        }
        string name = this.current.GetValue().ToString();
        advance();
        return name;
    }

    Block TryParseBlock()
    {
        // Opening "{"
        if (!currentTypeIs(Token.TokenType.T_LBRACE))
        {
            return null;
        }
        advance();

        // Statements
        List<Statement> statements = new List<Statement>();

        Statement st;
        while ((st = TryParseStatement()) != null)
        {

            statements.Add(st);

            CurrentTypeMustBe(Token.TokenType.T_SEMICOLON, new SemicolonExpectedException(current.GetLine(), current.GetPosition()));

        }

        // Closing "}"
        CurrentTypeMustBe(Token.TokenType.T_RBRACE, new ClosingBraceExpectedException(this.current.GetLine(), this.current.GetPosition()));


        return new Block(statements);
    }

    public void CurrentTypeMustBe(Token.TokenType type, SyntaxException syntaxException)
    {
        if (!currentTypeIs(type))
        {
            throw syntaxException;
        }
        advance();
    }

    Statement TryParseStatement()
    {
        //IfElseStatement
        Statement statement;
        statement = TryParseIfElseStatement();
        if (statement != null)
        {
            return statement;
        }

        // LoopStatement
        statement = TryParseLoopStatement();
        if (statement != null)
        {
            return statement;
        }

        //ReturnStatement
        statement = TryParseReturnStatement();
        if (statement != null)
        {
            return statement;
        }

        // ThrowStatement
        statement = TryParseThrowStatement();
        if (statement != null)
        {
            return statement;
        }

        // TryCatchStatement
        statement = TryParseTryCatchStatement();
        if (statement != null)
        {
            return statement;
        }

        // VarDefInitStatement or VarAssignStatement or FunCallStatement
        statement = TryParseVarDefOrVarAssignOrFunCallStatement();
        if (statement != null)
        {
            return statement;
        }

        // Unknown Statement
        return null;
    }

    IfElseStatement TryParseIfElseStatement()
    {
        // "if" keyword
        if (!currentTypeIs(Token.TokenType.T_IF))
        {
            return null;
        }
        advance();

        // Opening "("
        CurrentTypeMustBe(Token.TokenType.T_LPARENT, new OpeningParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // Condition
        Expression condition = TryParseCondition();
        if (condition == null)
        {
            throw new ConditionExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        // Closing ")"
        CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // IfBlock
        Block ifBlock = TryParseBlock();
        if (ifBlock == null)
        {
            throw new BlockExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        // "else" keyword
        if (!currentTypeIs(Token.TokenType.T_ELSE))
        {
            return new IfElseStatement(condition, ifBlock, null);
        }
        advance();

        // ElseBlock
        Block elseBlock = TryParseBlock();
        if (elseBlock == null)
        {
            throw new BlockExpectedStatementException(current.GetLine(), current.GetPosition());

        }

        return new IfElseStatement(condition, ifBlock, elseBlock);
    }

    LoopStatement TryParseLoopStatement()
    {
        // "while" keyword
        if (!currentTypeIs(Token.TokenType.T_WHILE))
        {
            return null;
        }
        advance();

        // Opening "("
        CurrentTypeMustBe(Token.TokenType.T_LPARENT, new OpeningParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // Condition
        Expression condition = TryParseCondition();
        if (condition == null)
        {
            throw new ConditionExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        // Closing ")"
        CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // Block
        Block block = TryParseBlock();
        if (block == null)
        {
            throw new BlockExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        return new LoopStatement(condition, block);


    }

    ReturnStatement TryParseReturnStatement()
    {
        // "return" keyword
        if (!currentTypeIs(Token.TokenType.T_RETURN))
        {
            return null;
        }
        advance();

        // Condition
        Expression argument = TryParseCondition();
        if (argument == null)
        {
            throw new ReturnExpressionExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        return new ReturnStatement(argument);
    }

    ThrowStatement TryParseThrowStatement()
    {
        // "throw" keyword
        if (!currentTypeIs(Token.TokenType.T_THROW))
        {
            return null;
        }
        advance();

        // Condition
        Expression argument = TryParseCondition();
        if (argument == null)
        {
            throw new ThrowExpressionExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        return new ThrowStatement(argument);
    }

    TryCatchStatement TryParseTryCatchStatement()
    {
        // "try" keyword
        if (!currentTypeIs(Token.TokenType.T_TRY))
        {
            return null;
        }
        advance();

        // tryBlock
        Block tryBlock = TryParseBlock();
        if (tryBlock == null)
        {
            throw new BlockExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        List<Catch> catches = new List<Catch>();
        // "catch" keyword
        if (!currentTypeIs(Token.TokenType.T_CATCH))
        {
            throw new CatchKeywordExpectedStatementException(current.GetLine(), current.GetPosition());
        }

        do
        {
            advance();

            // Catch filter
            CurrentTypeMustBe(Token.TokenType.T_LPARENT, new OpeningParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


            CatchFilter catchFilter = TryParseCatchFilter();
            if (catchFilter == null)
            {
                throw new CatchFilterExpectedStatementException(current.GetLine(), current.GetPosition());
            }

            // Closing ")"
            CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


            // Catch block

            Block catchBlock = TryParseBlock();
            if (catchBlock == null)
            {
                throw new BlockExpectedStatementException(current.GetLine(), current.GetPosition());
            }

            catches.Add(new Catch(catchFilter, catchBlock));


        } while (currentTypeIs(Token.TokenType.T_CATCH));


        return new TryCatchStatement(tryBlock, catches);
    }
    CatchFilter TryParseCatchFilter()
    {
        if (!currentTypeIs(Token.TokenType.T_LSBRACKET))
        {
            //Catch filter by condition
            Expression condition = TryParseCondition();
            if (condition == null)
            {
                throw new CatchFilterUnknownStatementException(current.GetLine(), current.GetPosition());
            }
            return new CatchFilter(condition);
        }

        // Catch filter by range

        // Opening "["
        advance();

        // Left codnition
        Expression leftCondition = TryParseCondition();
        if (leftCondition == null)
        {
            throw new CatchFilterUnknownStatementException(current.GetLine(), current.GetPosition());

        }

        // Ellipsis 
        CurrentTypeMustBe(Token.TokenType.T_ELLIPSIS, new EllipsisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        // Right condition
        Expression rightCondition = TryParseCondition();
        if (rightCondition == null)
        {
            throw new CatchFilterUnknownStatementException(current.GetLine(), current.GetPosition());
        }


        // Closing "]"
        CurrentTypeMustBe(Token.TokenType.T_RSBRACKET, new ClosingSBracketExpectedException(this.current.GetLine(), this.current.GetPosition()));


        return new CatchFilter(leftCondition, rightCondition);
    }
    Statement TryParseVarDefOrVarAssignOrFunCallStatement()
    {
        Statement statement;
        if (currentTypeIs(Token.TokenType.T_INT) || currentTypeIs(Token.TokenType.T_STRING))
        {
            Token.TokenType type = this.current.GetType();
            advance();

            // VarDefInitStatement
            statement = TryParseVarDefInitStatement(type);
            if (statement == null)
            {
                throw new InvalidStatementStatementException(current.GetLine(), current.GetPosition());
            }
            return statement;

        }
        else if (currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            string identifier = this.current.GetValue().ToString();
            advance();

            // VarDefInitStatement
            statement = TryParseVarDefInitStatement(identifier);
            if (statement != null)
            {
                return statement;
            }
            // VarAssignStatement
            statement = TryParseVarAssignStatement(identifier);
            if (statement != null)
            {
                return statement;
            }

            // FunCallStatement
            statement = TryParseFunCallStatement(identifier);
            if (statement != null)
            {
                return statement;
            }

            throw new InvalidStatementStatementException(current.GetLine(), current.GetPosition());

        }

        return null;
    }


    VarDefInitStatement TryParseVarDefInitStatement(Token.TokenType variableDataType)
    {
        // variable name
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            return null;
        }


        string varName = this.current.GetValue().ToString();
        advance();

        if (!currentTypeIs(Token.TokenType.T_ASSIGN))
        {
            // dataType varName 
            return new VarDefInitStatement(variableDataType, varName);
        }
        advance();

        // dataType varName "=" condition
        Expression condition = TryParseCondition();
        if (condition == null)
        {
            throw new IllegalVarInitializationStatementException(current.GetLine(), current.GetPosition());
        }


        return new VarDefInitStatement(variableDataType, varName, condition);
    }

    VarDefInitStatement TryParseVarDefInitStatement(string typeEnumName)
    {
        // variable name
        if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            return null;
        }
        string varName = this.current.GetValue().ToString();
        advance();

        if (!currentTypeIs(Token.TokenType.T_ASSIGN))
        {
            // dataType varName 
            return new VarDefInitStatement(typeEnumName, varName);
        }
        advance();

        // enumName varName "=" condition
        Expression condition = TryParseCondition();
        if (condition == null)
        {
            throw new IllegalVarInitializationStatementException(current.GetLine(), current.GetPosition());

        }

        return new VarDefInitStatement(typeEnumName, varName, condition);

    }


    VarAssignStatement TryParseVarAssignStatement(string varName)
    {
        if (!currentTypeIs(Token.TokenType.T_ASSIGN))
        {
            return null;
        }
        advance();

        // varName "=" condition
        Expression condition = TryParseCondition();
        if (condition == null)
        {
            throw new IllegalVarAssignmentStatementException(current.GetLine(), current.GetPosition());
        }

        return new VarAssignStatement(varName, condition);
    }

    FunCallStatement TryParseFunCallStatement(string funName)
    {
        // Opening "("
        if (!currentTypeIs(Token.TokenType.T_LPARENT))
        {
            return null;
        }
        advance();

        // Arguments
        List<Expression> funCallArgs = new List<Expression>();
        Expression funCallArg = null;

        funCallArg = TryParseCondition();
        if (funCallArg == null)
        {
            CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));
            return new FunCallStatement(funName);
        }

        funCallArgs.Add(funCallArg);
        while (currentTypeIs(Token.TokenType.T_COMMA))
        {
            advance();
            funCallArg = TryParseCondition();
            if (funCallArg == null)
            {
                throw new FunctionCallArgumentExpectedStatementException(current.GetLine(), current.GetPosition());
            }
            funCallArgs.Add(funCallArg);
        }


        // Closing ")"
        CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


        return new FunCallStatement(funName, funCallArgs);
    }

    Expression TryParseCondition()
    {
        Expression andCondition = TryParseAndCondition();

        if (andCondition == null)
        {
            return null;
        }

        List<Expression> andConditions = new List<Expression>();
        andConditions.Add(andCondition);

        while (currentTypeIs(Token.TokenType.T_OR))
        {
            advance();
            andCondition = TryParseAndCondition();
            if (andCondition == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());
            }
            andConditions.Add(andCondition);
        }
        if (andConditions.Count == 1)
            return andConditions[0];



        return new Condition(andConditions);
    }

    Expression TryParseAndCondition()
    {
        Expression relationCondition = TryParseRelationCondition();
        if (relationCondition == null)
        {
            return null;
        }

        List<Expression> relationConditions = new List<Expression>();
        relationConditions.Add(relationCondition);

        while (currentTypeIs(Token.TokenType.T_AND))
        {
            advance();
            relationCondition = TryParseRelationCondition();
            if (relationCondition == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());
            }
            relationConditions.Add(relationCondition);
        }

        if (relationConditions.Count == 1)
        {
            return relationConditions[0];
        }

        return new AndCondition(relationConditions);
    }

    Expression TryParseRelationCondition()
    {
        // Unary
        Expression leftPrimaryConditionKay = TryParsePrimaryCondition();
        if (leftPrimaryConditionKay == null)
        {
            return null;
        }

        if (!currentTypeIs(Token.TokenType.T_LESSTHAN) && !currentTypeIs(Token.TokenType.T_LESSEQUALS)
         && !currentTypeIs(Token.TokenType.T_MORETHAN) && !currentTypeIs(Token.TokenType.T_MOREEQUALS)
         && !currentTypeIs(Token.TokenType.T_EQUALS) && !currentTypeIs(Token.TokenType.T_NEQUALS))
        {
            return leftPrimaryConditionKay;
        }

        // Binary
        Token.TokenType binaryRelationOperator = this.current.GetType();
        advance();

        Expression rightPrimaryConditionKay = TryParsePrimaryCondition();
        if (rightPrimaryConditionKay == null)
        {
            throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());
        }

        return new RelationCondition(leftPrimaryConditionKay, rightPrimaryConditionKay, binaryRelationOperator);
    }

    Expression TryParsePrimaryCondition() 
    {
        Expression arithmeticStatement;
        // Unary negation
        bool ifNegated;

        if (currentTypeIs(Token.TokenType.T_NOT))
        {
            ifNegated = true;
            advance();

            // Arithmetic statements
            arithmeticStatement = TryParseArithmeticStatement();
            if (arithmeticStatement == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());
            }
            return new PrimaryConditionKayArithm(ifNegated, arithmeticStatement);
        }

        ifNegated = false;

        // Arithmetic statements
        arithmeticStatement = TryParseArithmeticStatement();
        if (arithmeticStatement == null)
        {
            return null;
        }
        return arithmeticStatement;
    }

    Expression TryParseArithmeticStatement()
    {
        // First AddArgs
        Expression addArg = TryParseAddArg();
        if (addArg == null)
        {
            return null;
        }
        List<Expression> addArgs = new List<Expression>();
        addArgs.Add(addArg);

        List<AddOperator> addOperators = new List<AddOperator>();

        while (currentTypeIs(Token.TokenType.T_PLUS) || currentTypeIs(Token.TokenType.T_MINUS))
        {
            // Operator
            Token.TokenType addOperator = this.current.GetType();
            addOperators.Add(new AddOperator(addOperator));
            advance();

            // Next AddArg
            addArg = TryParseAddArg();
            if (addArg == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());

            }
            addArgs.Add(addArg);
        }

        if (addArgs.Count == 1)
        {
            return addArgs[0];
        }
        return new ArithmeticStatement(addArgs, addOperators);
    }
    // a= -2*3+10
    Expression TryParseAddArg()
    {
        // First ArithmeticArg
        Expression arithmeticArg = TryParseArithmeticArg();
        if (arithmeticArg == null)
        {
            return null;
        }
        List<Expression> arithmeticArgs = new List<Expression>();
        arithmeticArgs.Add(arithmeticArg);

        List<MultOperator> multOperators = new List<MultOperator>();

        while (currentTypeIs(Token.TokenType.T_MUL) || currentTypeIs(Token.TokenType.T_DIV) || currentTypeIs(Token.TokenType.T_MODULO))
        {
            // Operator
            Token.TokenType multOperator = this.current.GetType();
            multOperators.Add(new MultOperator(multOperator));
            advance();

            // Next ArithmeticArg
            arithmeticArg = TryParseArithmeticArg();
            if (arithmeticArg == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());

            }
            arithmeticArgs.Add(arithmeticArg);
        }

        if (arithmeticArgs.Count == 1)
        {
            return arithmeticArgs[0];
        }

        return new AddArg(arithmeticArgs, multOperators);

    }

    Expression TryParseArithmeticArg()
    {
        // Text
        if (currentTypeIs(Token.TokenType.T_TEXT))
        {
            string text = this.current.GetValue().ToString();
            advance();
            return new ArgText(text);
        }


        // Unary "-" or "+"
        bool ifNegated = false;
        if (currentTypeIs(Token.TokenType.T_MINUS))
        {
            ifNegated = true;
            advance();

        }
        else if (currentTypeIs(Token.TokenType.T_PLUS))
        {
            ifNegated = false;
        }

        // Number
        if (currentTypeIs(Token.TokenType.T_INTCONST))
        {
            ulong number = (ulong)this.current.GetValue();
            advance();
            return new ArgNumber(number, ifNegated);
        }

        // Condition 
        if (currentTypeIs(Token.TokenType.T_LPARENT))
        {

            // Opening "("
            advance();

            // Condition

            Expression condition = TryParseCondition();
            if (condition == null)
            {
                throw new OperandExpectedExpressionException(current.GetLine(), current.GetPosition());

            }

            // Closing ")"
            CurrentTypeMustBe(Token.TokenType.T_RPARENT, new ClosingParenthesisExpectedException(this.current.GetLine(), this.current.GetPosition()));


            return new ArgCondition(condition, ifNegated);
        }

        // Enum Var Funcall
        if (currentTypeIs(Token.TokenType.T_IDENTIFIER))
        {
            string name = this.current.GetValue().ToString();
            advance();


            // Enum used
            if (currentTypeIs(Token.TokenType.T_DOT))
            {
                advance();
                if (this.current.GetType() != Token.TokenType.T_IDENTIFIER)
                {
                    throw new UnknownEnumeratorSyntaxException(); 
                }

                string name2 = this.current.GetValue().ToString();
                advance();
                if (!currentTypeIs(Token.TokenType.T_DOT))
                {
                    return new ArgEnumNameExtended(name, name2, ifNegated);
                }

                // Enum.Enumerator.Name or Enum.Enumerator.Value
                advance();
                if (!currentTypeIs(Token.TokenType.T_IDENTIFIER))
                {
                    throw new UnknownEnumeratorSyntaxException();
                }
                if ((string)current.GetValue() == "Name" || (string)current.GetValue() == "name")
                {
                    advance();
                    return new ArgEnumeratorName(name, name2);
                } else
                if ((string)current.GetValue() == "Value" || (string)current.GetValue() == "value")
                {
                    advance();
                    return new ArgEnumeratorValue(name, name2, ifNegated);
                } else
                {
                    throw new UnknownEnumeratorSyntaxException(); 
                }

            }

            // Function Call
            FunCallStatement funCallStatement = TryParseFunCallStatement(name);
            if (funCallStatement != null)
            {
                return new ArgFunCallStatement(funCallStatement, ifNegated);
            }

            // Variable
            return new ArgVariable(name, ifNegated);

        }

        return null;
    }


}

