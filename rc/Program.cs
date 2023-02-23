using rc.core;

namespace rc
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = "this.a = 1.23; // test \\n temp.hello = 1.23; // test \\n temp.i = \"Hello\"";

            var interpreter = new Interpreter();

            Console.ReadKey();
        }
    }
}