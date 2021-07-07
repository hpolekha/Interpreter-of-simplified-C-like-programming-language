namespace Components
{
    public interface INodeVisitor
    {
        void visit(MainProgram mainProgram);
        void visit(FunDefStatement funDefStatement);
        void visit(FunDefArg funDefArg);
        void visit(EnumDefStatement enumDefStatement);
        void visit(EnumDefArg enumDefArg);
        void visit(Block block);

        // Statements
        void visit(VarDefInitStatement varDefInitStatement);
        void visit(VarAssignStatement varAssignStatement);
        void visit(ThrowStatement throwStatement);
        void visit(ReturnStatement returnStatement);
        void visit(LoopStatement loopStatement);
        void visit(IfElseStatement ifElseStatement);
        void visit(FunCallStatement funCallStatement);

        // TryCatchStatement
        void visit(TryCatchStatement tryCatchStatement);
        void visit(CatchFilter catchFilter);
        void visit(Catch c);

        // Condition
        void visit(RelationCondition relationCondition);
        void visit(PrimaryConditionKayArithm primaryConditionKayArithm);
        void visit(Condition condition);
        void visit(AndCondition andCondition);

        // ArithmeticStatement

        void visit(ArgCondition argCondition);
        void visit(ArgVariable argVariable);
        void visit(ArgText argText);
        void visit(ArgEnumeratorName argEnumeratorName);
        void visit(ArgNumber argNumber);
        void visit(ArgEnumeratorValue argEnumeratorValue);

        void visit(ArgFunCallStatement argFunCallStatement);
        void visit(ArgEnumNameExtended argEnumNameExtended);
        void visit(ArithmeticStatement arithmeticStatement);
        void visit(AddArg addArg);
        void visit(AddOperator addOperator);
        void visit(MultOperator multOperator);

    }

}