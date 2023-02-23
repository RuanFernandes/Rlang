using System;
using rc.core;

namespace rc
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "this.a = 123;";

            var lexer = new Lexer(input);

            var tokens = lexer.Tokenize();

            foreach (var token in tokens)
            {
                Console.WriteLine(token.Type + " " + token.Value);
            }

            Console.ReadLine();
        }
    }
}