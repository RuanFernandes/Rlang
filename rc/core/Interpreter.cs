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
            _lexer.setInput("if (true) {   PrintL(\"Hello World!\", 123)   }");

            foreach (var token in _lexer.Tokenize())
            {
                if (token.Type == enums.TokenType.Function_Identifier)
                {
                    try
                    {
                        Function _function = _functionMap.getFunction(token.Value);
                        Console.WriteLine("Function found: " + _function.getName() + '\n');
                        _function.Execute(new string[] { "Hello World!", "123" });
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("Function not found: " + token.Value);
                    }


                }
                else
                {
                    //Console.WriteLine(token.Type + ": \"" + token.Value + "\"");
                }
            }
        }

    }
}