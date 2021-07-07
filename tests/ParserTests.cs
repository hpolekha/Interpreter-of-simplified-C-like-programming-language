// namespace Tests
// {

//     using Xunit;
//     using Lexer.Source;
//     using Lexer.Scanner;
//     using Lexer.Token;
//     using System.Collections.Generic;
//     using Components;



//     public class ParserTests
//     {
//         [Fact]
//         public void EnumDefOneArgWithoutValueTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(){
//                             new EnumDefStatement("Days",
//                                 new List<EnumDefArg>(){
//                                     new EnumDefArg("Monday", null)
//                                 }),
//                         }, new List<FunDefStatement>()
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void EnumDefTwoArgWithoutValueTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday, Tuesday }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(){
//                             new EnumDefStatement("Days",
//                                 new List<EnumDefArg>(){
//                                     new EnumDefArg("Monday", null),
//                                     new EnumDefArg("Tuesday", null)
//                                 }),
//                         }, new List<FunDefStatement>()
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void EnumDefTwoArgWithValuesTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday = 12, Tuesday = 15 }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(){
//                             new EnumDefStatement("Days",
//                                 new List<EnumDefArg>(){
//                                     new EnumDefArg("Monday", 12),
//                                     new EnumDefArg("Tuesday", 15)
//                                 }),
//                         }, new List<FunDefStatement>()
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void EnumDefTwoArgFirstWithValueTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday = 123, Tuesday }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(){
//                             new EnumDefStatement("Days",
//                                 new List<EnumDefArg>(){
//                                     new EnumDefArg("Monday", 123),
//                                     new EnumDefArg("Tuesday", null)
//                                 }),
//                         }, new List<FunDefStatement>()
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void EnumDefTwoArgLastWithValueTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday, Tuesday = 568 }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(){
//                             new EnumDefStatement("Days",
//                                 new List<EnumDefArg>(){
//                                     new EnumDefArg("Monday", null),
//                                     new EnumDefArg("Tuesday", 568)
//                                 }),
//                         }, new List<FunDefStatement>()
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void EnumDefEmptyErrorTest()
//         {
//             // Arrange
//             string code = "enum Days {  }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }

//         [Fact]
//         public void EnumDefExtraCommaErrorTest()
//         {
//             // Arrange
//             string code = "enum Days { Monday, Tuesday = 568, }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }

//         [Fact]
//         public void FunDefWithoutParamAndNoStatementsTest()
//         {
//             // Arrange
//             string code = "int fun(){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(), new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }
//         [Fact]
//         public void FunDefStatementsNoClosingParenthErrorTest()
//         {
//             // Arrange
//             string code = "int fun({}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }
//                 [Fact]
//         public void FunDefStatementsNoOppeningParenthErrorTest()
//         {
//             // Arrange
//             string code = "int fun){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }
//                 [Fact]
//         public void FunDefStatementsNoBlockErrorTest()
//         {
//             // Arrange
//             string code = "int fun()";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }

//                         [Fact]
//         public void GlobalStatementErrorTest()
//         {
//             // Arrange
//             string code = "int fun;";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }

//         [Fact]
//         public void FunDefWithOneIntParamAndNoStatementsTest()
//         {
//             // Arrange
//             string code = "int fun(int a){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunDefWithTwoIntStringParamAndNoStatementsTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING, "b")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunDefWithEnumParamAndNoStatementsTest()
//         {
//             // Arrange
//             string code = "int fun(int a, EnumName b){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a"),
//                                     new FunDefArg(Token.TokenType.T_IDENTIFIER, "EnumName", "b")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunDefWithThreeParamAndNoStatementsTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b, EnumName b){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING, "b"),
//                                     new FunDefArg(Token.TokenType.T_IDENTIFIER, "EnumName", "b")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }
//         [Fact]
//         public void FunDefRetTypeStringTest()
//         {
//             // Arrange
//             string code = "string fun(int a){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_STRING, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunDefRetTypeEnumTest()
//         {
//             // Arrange
//             string code = "EnumName fun(int a, string b){}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_IDENTIFIER, "EnumName", "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING, "b")
//                                 }, new Block(new List<Statement>()))
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void VarDefStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ int i; string j; EnumName e;}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new VarDefInitStatement(Token.TokenType.T_INT, null, "i", null),
//                                         new VarDefInitStatement(Token.TokenType.T_STRING, null, "j", null),
//                                         new VarDefInitStatement(Token.TokenType.T_IDENTIFIER, "EnumName", "e", null)
//                                 })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void VarDefInitStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ int i = 2;}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new VarDefInitStatement(Token.TokenType.T_INT, null, "i",
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      }))) // TO DO
//                                                 })
//                                             }))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void VarDefAssignStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ i = 2;}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new VarAssignStatement("i", new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      })))
//                                                 })
//                                             }))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void ThrowStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ throw 2;}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new ThrowStatement(
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      })))
//                                                 })
//                                             }))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void ReturnStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ return 2;}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new ReturnStatement(
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      })))
//                                                 })
//                                             }))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }
//         [Fact]
//         public void LoopStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ while(x){};}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new LoopStatement(
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgVariable("x")
//                                                         })
//                                                      })))
//                                                 })
//                                             }), new Block(new List<Statement>()))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void LoopStatementSemicolonMissingErrorTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ while(x){}}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert
//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());


//         }

//         [Fact]
//         public void ifElseStatementTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ if(x) {} else {};}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new IfElseStatement(
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgVariable("x")
//                                                         })
//                                                      })))
//                                                 })
//                                             }), new Block(new List<Statement>()), new Block(new List<Statement>()))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void ifElseStatementSemicolonMissingTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ if(x) {} else {}}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert

//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());
//         }
//         [Fact]
//         public void ConditionRelationOperatorErrorTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ if(x 2) {} else {};}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act

//             // Assert
//             Assert.Throws<SyntaxException>(() => parser.ParseProgram());


//         }

//         [Fact]
//         public void FunCallStatementWithoutParamTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ fun();}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new FunCallStatement("fun", new List<Condition>(){ })
//                                     }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunCallStatementIntParamTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ fun(2);}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new FunCallStatement("fun", new List<Condition>(){
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      })))
//                                                 })
//                                             })
//                                         })
//                                      }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunCallStatementEnumParamTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ fun(EnumName.Value);}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new FunCallStatement("fun", new List<Condition>(){
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgEnumNameExtended("EnumName", "Value")
//                                                         })
//                                                      })))
//                                                 })
//                                             })
//                                         })
//                                     }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunCallStatementStringParamTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ fun(\"text\");}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new FunCallStatement("fun", new List<Condition>(){
//                                                 new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgText("text")
//                                                         })
//                                                      })))
//                                                 })
//                                             })
//                                         })
//                                      }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void FunCallStatementSeveralParamTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ fun(2, EnumName.Value, \"text\");}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new FunCallStatement("fun", new List<Condition>(){
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgNumber(2)
//                                                         })
//                                                      })))
//                                                 })
//                                             }),
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgEnumNameExtended("EnumName", "Value")
//                                                         })
//                                                      })))
//                                                 })
//                                             }),
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                         new AddArg(new List<ArithmeticArg>(){
//                                                             new ArgText("text")
//                                                         })
//                                                      })))
//                                                 })
//                                             })
//                                         })
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void TryCatchStatementValueFilterTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ try{} catch(2){}; }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new TryCatchStatement(new Block(new List<Statement>()), new List<Catch>(){
//                                             new Catch(new CatchFilter(
//                                                 new Condition(new List<AndCondition>(){
//                                                     new AndCondition(new List<RelationCondition>(){
//                                                         new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                             new AddArg(new List<ArithmeticArg>(){
//                                                                 new ArgNumber(2)
//                                                             })
//                                                         })))
//                                                     })
//                                                 })
//                                             ), new Block(new List<Statement>()))
//                                         })
//                                      }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void TryCatchStatementRangeFilterTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ try{}catch([ EnumName.Value ... EnumName.AnotherValue ]){}; }";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new TryCatchStatement(new Block(new List<Statement>()), new List<Catch>(){
//                                             new Catch(new CatchFilter(
//                                                 new Condition(new List<AndCondition>(){
//                                                     new AndCondition(new List<RelationCondition>(){
//                                                         new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                             new AddArg(new List<ArithmeticArg>(){
//                                                                 new ArgEnumNameExtended("EnumName", "Value")
//                                                             })
//                                                         })))
//                                                     })
//                                                 }),
//                                                 new Condition(new List<AndCondition>(){
//                                                     new AndCondition(new List<RelationCondition>(){
//                                                         new RelationCondition(new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                             new AddArg(new List<ArithmeticArg>(){
//                                                                 new ArgEnumNameExtended("EnumName", "AnotherValue")
//                                                             })
//                                                         })))
//                                                     })
//                                                 })

//                                             ), new Block(new List<Statement>()))
//                                         })
//                                      }
//                                 )
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//         [Fact]
//         public void ConditionRelationOperatorTest()
//         {
//             // Arrange
//             string code = "int fun(int a, string b){ if(x > 2) {} else {};}";
//             Source source = new Source(new System.IO.StringReader(code));
//             Scanner scanner = new Scanner(source);
//             Parser parser = new Parser(scanner);
//             // Act
//             MyProgram program = parser.ParseProgram();

//             // Assert

//             Assert.True(
//                 program.Equals(
//                     new MyProgram(
//                         new List<EnumDefStatement>(),
//                         new List<FunDefStatement>(){
//                             new FunDefStatement(Token.TokenType.T_INT, null, "fun",
//                                 new List<FunDefArg>(){
//                                     new FunDefArg(Token.TokenType.T_INT, null, "a"),
//                                     new FunDefArg(Token.TokenType.T_STRING,null, "b")
//                                 },
//                                 new Block(
//                                     new List<Statement>(){
//                                         new IfElseStatement(
//                                             new Condition(new List<AndCondition>(){
//                                                 new AndCondition(new List<RelationCondition>(){
//                                                     new RelationCondition(
//                                                         new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                             new AddArg(new List<ArithmeticArg>(){
//                                                                 new ArgVariable("x")
//                                                             })
//                                                         })),
//                                                         new PrimaryConditionKayArithm(false, new ArithmeticStatement(new List<AddArg>(){
//                                                             new AddArg(new List<ArithmeticArg>(){
//                                                                 new ArgNumber(2)
//                                                             })
//                                                         })),
//                                                         Token.TokenType.T_MORETHAN
//                                                     )
//                                                 })
//                                             }), new Block(new List<Statement>()), new Block(new List<Statement>()))
//                                      })
//                             )
//                         }
//                     )
//                 )
//             );
//         }

//     }
// }
