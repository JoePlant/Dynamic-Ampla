using System.Dynamic;

namespace Dynamic.Ampla.Binders
{
    public interface IDynamicBinder
    {
        dynamic Invoke(DynamicViewPoint viewPoint, InvokeMemberBinder binder, object[] args);
    }
}