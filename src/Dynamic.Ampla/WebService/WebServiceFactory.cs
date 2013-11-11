using System;

namespace Dynamic.Ampla.WebService
{
    public class WebServiceFactory<T>
    {
        public static Func<T> Factory { private get; set; }

        public static T Create()
        {
            return Factory();
        }
    }
}