using System;
using System.Collections.Generic;
using System.Dynamic;
using Dynamic.Ampla.AmplaData2008;

namespace Dynamic.Ampla.Binders
{
    public class FindByIdDynamicBinder : DynamicBinder, IDynamicBinder
    {
        public FindByIdDynamicBinder(IDataWebServiceClient webServiceClient, ICredentialsProvider credentialsProvider) : base(webServiceClient, credentialsProvider)
        {
        }

        public dynamic Invoke(DynamicViewPoint point, InvokeMemberBinder binder, object[] args)
        {
            string location = point.Location;

            string idValue = args.Length == 1 ? Convert.ToString(args[0]) : "";

            GetDataRequest request = new GetDataRequest
                {
                    Credentials = GetCredentials(),
                    Filter = new DataFilter
                        {
                            Location = location, 
                            Criteria = new [] {new FilterEntry {Name = "Id", Value = idValue}},
                        },
                    View = new GetDataView
                        {
                            Module = point.AmplaModule
                        },
                    OutputOptions = new GetDataOutputOptions
                        {
                            ResolveIdentifiers = true
                        },
                };
            GetDataResponse response = WebServiceClient.GetData(request);
        
            ExpandoObject expando = new ExpandoObject();
            IDictionary<string, object> dictionary = expando;
    
            dictionary.Add("Id", args[0]);
            dictionary.Add("Location", point.Location);
            dictionary.Add("Module", point.Module);

            return expando;
        }
    }
}