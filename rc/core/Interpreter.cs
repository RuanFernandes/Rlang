using System;

namespace rc.core
{
    public class Interpreter
    {

        private Lexer _lexer;

        public Interpreter()
        {
            _lexer = new Lexer();

            _lexer.setInput("if (true) {   test(\"Hello\", 123)   }");
            var data = _lexer.Tokenize();

            foreach (var token in data)
            {
                Console.WriteLine(token.Type + " " + token.Value);
            }
        }

    }
}