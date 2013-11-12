using System.Dynamic;
using Dynamic.Ampla.Methods.Binders;

namespace Dynamic.Ampla.Methods.Strategies
{
    public abstract class Strategy : IStrategy
    {
        public abstract IDynamicBinder GetBinder(InvokeMemberBinder binder, object[] args);

        protected bool MethodCalled(InvokeMemberBinder binder, string name)
        {
            return binder.Name == name;
        }
    }
}