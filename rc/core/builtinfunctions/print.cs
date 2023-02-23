using rc.core;

namespace rc.core.builtinfunctions
{
    public class Print : Function
    {
        public override object? Execute(string[] args)
        {
            string output = String.Join(" ", args);

            Console.WriteLine(output);
            return null;
        }

        public Print(string[] argvs) : base("print", "Prints the arguments to the console", argvs, new string[] { "print(Hello World)", "prints Hello World!" })
        {
        }
    }
}