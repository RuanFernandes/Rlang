namespace rc.core
{
    public class FunctionMap
    {
        private Dictionary<string, Function> _functions = new Dictionary<string, Function>();

        public Function getFunction(string name)
        {
            if (!_functions.ContainsKey(name))
                throw new Exception("Function " + name + " not found");

            return _functions[name];
        }

        public void AddFunction(Function function)
        {
            _functions.Add(function.getName(), function);
        }

        public object? ExecuteFunction(string name, string[] args)
        {
            if (!_functions.ContainsKey(name))
                throw new Exception("Function not found");

            return _functions[name].Execute(args);
        }

        public void PrintFunctions()
        {
            foreach (var function in _functions)
            {
                Console.WriteLine(function.Key);
            }
        }

        public void PrintFunction(string name)
        {
            if (!_functions.ContainsKey(name))
                throw new Exception("Function not found");

            var function = _functions[name];

            Console.WriteLine(function.getName());
            Console.WriteLine(function.Description);
            Console.WriteLine("Examples:");
            foreach (var example in function.Examples)
            {
                Console.WriteLine(example);
            }
        }

    }

    public abstract class Function
    {
        private string Name { get; set; }
        public string Description { get; set; }
        public string[] Examples { get; set; }

        public string getName() { return Name; }

        public virtual object? Execute(string[] args)
        {
            return "Not implemented";
        }

        public Function(string name, string description, string[] examples)
        {
            Name = name;
            Description = description;
            Examples = examples;
        }
    }
}