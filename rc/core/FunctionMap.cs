namespace rc.core
{
    public class FunctionMap
    {
        private Dictionary<string, Function> _functions = new Dictionary<string, Function>();

        public void AddFunction(Function function)
        {
            _functions.Add(function.Name, function);
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

            Console.WriteLine(function.Name);
            Console.WriteLine(function.Description);
            Console.WriteLine("Parameters:");
            foreach (var parameter in function.Parameters)
            {
                Console.WriteLine(parameter);
            }
            Console.WriteLine("Examples:");
            foreach (var example in function.Examples)
            {
                Console.WriteLine(example);
            }
        }

    }

    public abstract class Function
    {
        public string Name
        {
            get
            {
                return this.Name.ToLower();
            }
            set
            {
                if (!char.IsLetter(value[0]))
                    throw new Exception("Function name must start with a letter");

                this.Name = value;
            }
        }
        public string Description { get { return Description; } set { return; } }
        public string[] Parameters { get { return Parameters; } set { return; } }
        public string[] Examples { get { return Examples; } set { return; } }
        public virtual object? Execute(string[] args)
        {
            return "Not implemented";
        }

        public Function(string name, string description, string[] parameters, string[] examples)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
            Examples = examples;
        }
    }
}