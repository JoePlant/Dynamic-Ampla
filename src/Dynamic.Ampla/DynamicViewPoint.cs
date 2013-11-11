using System.Collections.Generic;
using System.Dynamic;
using Dynamic.Ampla.Binders;
using Dynamic.Ampla.Strategies;

namespace Dynamic.Ampla
{
    public class DynamicViewPoint : DynamicObject
    {
        public DynamicViewPoint(string location = "", string module = "")
        {
            Module = module;
            Location = location;
        }

        public string Module { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// A helpful query tool
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            List<IStrategy> strategies = GetStrategies(this);

            foreach (var strategy in strategies)
            {
                IDynamicBinder dynamicBinder = strategy.GetBinder(binder, args);
                if (dynamicBinder != null)
                {
                    result = dynamicBinder.Invoke(this, binder, args);
                    return true;
                }
            }
            result = null;
            return false;
        }


        protected static List<IStrategy> GetStrategies(DynamicViewPoint point)
        {
            return new List<IStrategy> {new FindByIdStrategy()};
        }

    }
}
