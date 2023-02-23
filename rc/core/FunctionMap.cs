namespace rc.core
{
    public class FunctionMap
    {
        private Dictionary<string, Function> _functions = new Dictionary<string, Function>();


    }

    public abstract class Function
    {
        private string Name
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
        private string Description { get; set; }
        private string[] Parameters { get; set; }
        private string[] Examples { get; set; }
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