using System;
using rc.core.builtinfunctions;

namespace rc.core
{
    public class Interpreter
    {

        private Lexer _lexer;
        private FunctionMap _functionMap;

        public Interpreter()
        {
            _functionMap = new FunctionMap();
            _functionMap.AddFunction(new PrintL());

            _lexer = new Lexer();
            _lexer.setInput("if (true) {   PrintL(\"Hello\", 123)   }");

            foreach (var token in _lexer.Tokenize())
            {
                Console.WriteLine(token.Type + ": \"" + token.Value + "\"");
            }
        }

    }
}