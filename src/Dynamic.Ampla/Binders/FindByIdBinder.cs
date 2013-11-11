using System.Dynamic;

namespace Dynamic.Ampla.Binders
{
    public class FindByIdDynamicBinder : IDynamicBinder
    {
        public dynamic Invoke(DynamicViewPoint point, InvokeMemberBinder binder, object[] args)
        {
            return new {Id = args[0], point.Module, point.Location}.ToExpando();
        }
    }
}