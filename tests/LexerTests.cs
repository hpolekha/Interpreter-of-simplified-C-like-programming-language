// namespace Tests
// {

// using Xunit;
// using Lexer.Source;
// using Lexer.Scanner;
// using Lexer.Token;


// public class LexerTests
// {
//     [Fact]
//     public void EmptySourceTest()
//     {
//         // Arrange
//         string code = "";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_END, "", 1, 1));
//     }

//     [Fact]
//     public void IdentifierTest()
//     {
//         // Arrange
//         string code = "abc";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_IDENTIFIER, "abc", 1, 1));
//     }

//     [Fact]
//     public void IdentifierSpacesTest()
//     {
//         // Arrange
//         string code = "   abc";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_IDENTIFIER, "abc", 1, 4));
//     }

//     [Fact]
//     public void IdentifierNextLineTest()
//     {
//         // Arrange
//         string code = "   \n abc";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_IDENTIFIER, "abc", 2, 2));
//     }

//     [Fact]
//     public void IdentifierComplexTest()
//     {
//         // Arrange
//         string code = "gh23_q743";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_IDENTIFIER, "gh23_q743", 1, 1));
//     }

//     [Fact]
//     public void UnknownSymbolTest()
//     {
//         // Arrange
//         string code = "@";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Unknown symbol", ex.Message);
//     }

//     [Fact]
//     public void IdentifierTooLongTest()
//     {
//         // Arrange
//         string code = "abcdeabcdeabcdeabcdeabcdeabc";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         //Token token = scanner.GetNextToken();

//         // Assert
//         //Assert.True(token == new Token(Token.TokenType.T_END, "", 1, 1));
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Identifier is too long", ex.Message);
//     }

//     [Fact]
//     public void KeywordMainTest()
//     {
//         // Arrange
//         string code = "main";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MAIN, "main", 1, 1));

//     }

//     [Fact]
//     public void KeywordEnumTest()
//     {
//         // Arrange
//         string code = " enum";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_ENUM, "enum", 1, 2));

//     }

//     [Fact]
//     public void KeywordIntTest()
//     {
//         // Arrange
//         string code = "int";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_INT, "int", 1, 1));

//     }

//     [Fact]
//     public void KeywordStringTest()
//     {
//         // Arrange
//         string code = "string";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_STRING, "string", 1, 1));
//     }

//     [Fact]
//     public void KeywordIfTest()
//     {
//         // Arrange
//         string code = "if";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_IF, "if", 1, 1));
//     }

//     [Fact]
//     public void KeywordWhileTest()
//     {
//         // Arrange
//         string code = "while";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_WHILE, "while", 1, 1));
//     }

//     [Fact]
//     public void KeywordElseTest()
//     {
//         // Arrange
//         string code = "else";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_ELSE, "else", 1, 1));
//     }

//     [Fact]
//     public void KeywordThrowTest()
//     {
//         // Arrange
//         string code = "throw";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_THROW, "throw", 1, 1));
//     }

//     [Fact]
//     public void KeywordReturnTest()
//     {
//         // Arrange
//         string code = "return";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_RETURN, "return", 1, 1));
//     }

//     [Fact]
//     public void KeywordVoidTest()
//     {
//         // Arrange
//         string code = "void";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_VOID, "void", 1, 1));
//     }

//     [Fact]
//     public void KeywordTryTest()
//     {
//         // Arrange
//         string code = "try";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_TRY, "try", 1, 1));
//     }

//     [Fact]
//     public void KeywordCatchTest()
//     {
//         // Arrange
//         string code = "catch";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_CATCH, "catch", 1, 1));
//     }

//     [Fact]
//     public void TextTest()
//     {
//         // Arrange
//         string code = "\"Hello\"";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);

//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_TEXT, "Hello", 1, 1));
//     }

//     [Fact]
//     public void TextBackslashText()
//     {
//         // Arrange
//         string code = "\"Hello \\\"Anna\\\" \"";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_TEXT, "Hello \"Anna\" ", 1, 1));
//     }

//     [Fact]
//     public void TextEmptyStringTest()
//     {
//         // Arrange
//         string code = "\"\"";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_TEXT, "", 1, 1));
//     }

//     [Fact]
//     public void TextLongTest()
//     {
//         // Arrange
//         string generatedText = "";
//         for (uint i = 0; i < 2048; i++)
//         {
//             generatedText += 'a';
//         }
//         string code = '\"' + generatedText + '\"';
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_TEXT, generatedText, 1, 1));
//     }

//     [Fact]
//     public void TextTooLongTest()
//     {
//         // Arrange
//         string generatedText = "";
//         for (uint i = 0; i < 2049; i++)
//         {
//             generatedText += 'a';
//         }
//         string code = '\"' + generatedText + '\"';
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException exception = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Argument is out of range", exception.Message);
//     }

//     [Fact]
//     public void TextMissingQuoteTest()
//     {
//         // Arrange
//         string code = "\"Hello";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException exception = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Missing a closing quote for the string value", exception.Message);
//     }

//     [Fact]
//     public void SeparatorRParentTest()
//     {
//         // Arrange
//         string code = ")";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_RPARENT, ")", 1, 1));
//     }

//     [Fact]
//     public void SeparatorLParentTest()
//     {
//         // Arrange
//         string code = "(";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_LPARENT, "(", 1, 1));
//     }

//     [Fact]
//     public void SeparatorRBraceTest()
//     {
//         // Arrange
//         string code = "}";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_RBRACE, "}", 1, 1));
//     }

//     [Fact]
//     public void SeparatorLBraceTest()
//     {
//         // Arrange
//         string code = "{";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_LBRACE, "{", 1, 1));
//     }
//     [Fact]
//     public void SeparatorRSBracketTest()
//     {
//         // Arrange
//         string code = "]";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_RSBRACKET, "]", 1, 1));
//     }

//     [Fact]
//     public void SeparatorLSBracketTest()
//     {
//         // Arrange
//         string code = "[";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_LSBRACKET, "[", 1, 1));
//     }

//     [Fact]
//     public void SeparatorSemicolonTest()
//     {
//         // Arrange
//         string code = ";";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_SEMICOLON, ";", 1, 1));
//     }

//     [Fact]
//     public void SeparatorCommaTest()
//     {
//         // Arrange
//         string code = ",";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_COMMA, ",", 1, 1));
//     }

//     [Fact]
//     public void SeparatorDotTest()
//     {
//         // Arrange
//         string code = ".";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_DOT, ".", 1, 1));
//     }

//     [Fact]
//     public void SeparatorEllipsisTest()
//     {
//         // Arrange
//         string code = "...";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_ELLIPSIS, "...", 1, 1));
//     }

//     [Fact]
//     public void SeparatorWrongEllipsisTest()
//     {
//         // Arrange
//         string code = "..";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Invalid operator", ex.Message);
//     }

//     [Fact]
//     public void OperatorPlusTest()
//     {
//         // Arrange
//         string code = "+";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_PLUS, "+", 1, 1));
//     }

//     [Fact]
//     public void OperatorMinusTest()
//     {
//         // Arrange
//         string code = "-";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MINUS, "-", 1, 1));
//     }

//     [Fact]
//     public void OperatorMulTest()
//     {
//         // Arrange
//         string code = "*";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MUL, "*", 1, 1));
//     }

//     [Fact]
//     public void OperatorDivTest()
//     {
//         // Arrange
//         string code = "/";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_DIV, "/", 1, 1));
//     }

//     [Fact]
//     public void OperatorModuloTest()
//     {
//         // Arrange
//         string code = "%";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MODULO, "%", 1, 1));
//     }

//     [Fact]
//     public void OperatorAssignTest()
//     {
//         // Arrange
//         string code = "=";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_ASSIGN, "=", 1, 1));
//     }

//     [Fact]
//     public void OperatorEqualsTest()
//     {
//         // Arrange
//         string code = "==";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_EQUALS, "==", 1, 1));
//     }

//     [Fact]
//     public void OperatorNegationTest()
//     {
//         // Arrange
//         string code = "!";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_NOT, "!", 1, 1));
//     }

//     [Fact]
//     public void OperatorNotEqualsTest()
//     {
//         // Arrange
//         string code = "!=";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_NEQUALS, "!=", 1, 1));
//     }

//     [Fact]
//     public void OperatorMoreThanTest()
//     {
//         // Arrange
//         string code = ">";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MORETHAN, ">", 1, 1));
//     }

//     [Fact]
//     public void OperatorMoreEqualsTest()
//     {
//         // Arrange
//         string code = ">=";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_MOREEQUALS, ">=", 1, 1));
//     }

//     [Fact]
//     public void OperatorLessThanTest()
//     {
//         // Arrange
//         string code = "<";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_LESSTHAN, "<", 1, 1));
//     }

//     [Fact]
//     public void OperatorLessEqualsTest()
//     {
//         // Arrange
//         string code = "<=";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_LESSEQUALS, "<=", 1, 1));
//     }

//     [Fact]
//     public void OperatorOrTest()
//     {
//         // Arrange
//         string code = "||";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_OR, "||", 1, 1));
//     }
    
//     [Fact]
//     public void OperatorWrongOrTest()
//     {
//         // Arrange
//         string code = "|";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Invalid operator", ex.Message);
//     }


//     [Fact]
//     public void OperatorAndTest()
//     {
//         // Arrange
//         string code = "&&";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();

//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_AND, "&&", 1, 1));
//     }

//     [Fact]
//     public void OperatorWrongAndTest()
//     {
//         // Arrange
//         string code = "&";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Invalid operator", ex.Message);
//     }

//     [Fact]
//     public void NumberOneZeroTest()
//     {
//         // Arrange
//         string code = "0124";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         Token token = scanner.GetNextToken();
        
//         // Assert
//         Assert.True(token == new Token(Token.TokenType.T_INTCONST, 124, 1, 1));
//     }

//     [Fact]
//     public void NumberTooLongTest()
//     {
//         // Arrange
//         string generatedText = "";
//         for(uint i = 0; i < 11; i++)
//         {
//             generatedText += '0';
//         }
//         string code =  generatedText + '1';
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Limit of zeros exceeded", ex.Message);
//     } 

//     [Fact]
//     public void NumberAouOfRangeTest()
//     {
//         // Arrange
//         string code =  "2147483448";
//         Source source = new Source(new System.IO.StringReader(code));
//         Scanner scanner = new Scanner(source);
//         // Act
//         // Assert
//         LexerException ex = Assert.Throws<LexerException>(() => scanner.GetNextToken());
//         Assert.Equal("Argument out of range", ex.Message);
//     }

// }
// }
