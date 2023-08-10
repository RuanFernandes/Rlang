namespace rc.core.builtinfunctions
{
    public class PrintL : Function
    {
        public override object? Execute(string[] args)
        {
            string output = String.Join(" ", args);

            Console.WriteLine(output);
            return null;
        }

        public PrintL() : base("PrintL", "Prints the arguments to the console", new string[] { "print(string)", "prints String!" })
        {
        }
    }
}