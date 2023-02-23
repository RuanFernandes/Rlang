﻿using System;
using rc.core;

namespace rc
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "this.a = 1 23;";

            var lexer = new Lexer(input);

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