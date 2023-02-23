using System;
using rc.core;

namespace rc
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "this.a = 1.23; // test \\n temp.hello = 1.23; // test";

            var lexer = new Lexer(input);

            Console.WriteLine("Input: " + input + "\n");

            try
            {
                var tokens = lexer.Tokenize();
                foreach (var token in tokens)
                {
                    Console.WriteLine(token.Type + " " + token.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}