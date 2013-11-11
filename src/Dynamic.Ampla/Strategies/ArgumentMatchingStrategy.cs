using System.Dynamic;
using System.Linq;

namespace Dynamic.Ampla.Strategies
{
    public class ArgumentMatchingStrategy
    {
        private readonly Argument[] arguments;
        public ArgumentMatchingStrategy(params Argument[] arguments)
        {
            this.arguments = arguments;
        }

        public bool Matches(InvokeMemberBinder binder, object[] args)
        {
            return args.Length == arguments.Length && arguments.All(argument => argument.Matches(binder, args));
        }
    }
}