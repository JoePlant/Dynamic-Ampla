using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Dynamic.Ampla.AmplaData2008;
using Dynamic.Ampla.AmplaData2008.Binding;

namespace Dynamic.Ampla.Methods.Binders
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
        
            List<dynamic> records = new List<dynamic>();
            IAmplaBinding binding = new AmplaGetDataBinding(response, records);
            if (binding.Validate() && binding.Bind())
            {
                return records.FirstOrDefault();
            }
            return null;
        }
    }
}