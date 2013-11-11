using System.Dynamic;
using Dynamic.Ampla.Binders;

namespace Dynamic.Ampla.Strategies
{
    /// <summary>
    ///     Interface for finding Dynamic Binders using the method names and arguments
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Gets the dynamic binder.
        /// </summary>
        /// <param name="binder">The binder.</param>
        /// <param name="args">The arguments.</param>
        IDynamicBinder GetBinder(InvokeMemberBinder binder, object[] args);
    }
}