using System;
using Lexer.Source;
using Lexer.Token;
using Lexer.Scanner;
using System.IO;
using Components;
using Exceptions;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = "code.txt";
            if (args.Length > 0)
            {
                filePath = args[0];
            }
            try
            {
                using (StreamReader stream = File.OpenText(filePath))
                {
                    //tokenizationOfFile(stream);
                    ExecureCode(stream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

        }

        static void ExecureCode(TextReader textReader)
        {
            Source source = new Source(textReader);
            Scanner scanner = new Scanner(source);
            Parser parser = new Parser(scanner);
            MainProgram program;
            try
            {
                program = parser.ParseProgram();
                Interpreter0 interpreter = new Interpreter0(program);
                interpreter.Execute();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        // static void parsingFile(TextReader textReader)
        // {
        //     Source source = new Source(textReader);
        //     Scanner scanner = new Scanner(source);
        //     Parser parser = new Parser(scanner);
        //     MainProgram program;
        //     try
        //     {
        //         program = parser.ParseProgram();
        //     }
        //     catch (SyntaxException e)
        //     {
        //         Console.WriteLine(e.ToString());
        //     }

        // }


        //         static void tokenizationOfFile(TextReader textReader)
        //         {
        //             Source source = new Source(textReader);
        //             Scanner scanner = new Scanner(source);
        //             Token token;
        //             try
        //             {
        //                 do
        //                 {
        //                     token = scanner.GetNextToken();
        //                     Console.WriteLine(token.getType() + " (" + token.getLine() + ":" + token.getPosition() + ")");
        //                 } while (token.getType() != Token.TokenType.T_END);
        //             }
        //             catch (LexerException e)
        //             {
        //                 Console.WriteLine(e.ToString());
        //             }

        //         }
    }
}
//     static void tokenizationOfFile(string path)
//     {
//         Source source;
//         Scanner scanner;
//         Token token;
//         try
//         {
//             source = new SourceFile(path);
//         }
//         catch (IOException e)
//         {
//             Console.WriteLine("Error: " + e.Message);
//             return;
//         }

//         scanner = new Scanner(source);
//         try
//         {
//             do
//             {
//                 token = scanner.GetNextToken();
//                 Console.WriteLine(token.getType() + " (" + token.getLine() + ":" + token.getPosition() + ")");
//             } while (token.getType() != Token.TokenType.T_END);
//         }
//         catch (LexerException e)
//         {
//             Console.WriteLine(e.ToString());
//         }

//     }
// }
// }
