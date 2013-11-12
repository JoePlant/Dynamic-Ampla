
using Dynamic.Ampla.AmplaData2008;

namespace Dynamic.Ampla.Methods.Binders
{
    public class DynamicBinder 
    {
        private readonly ICredentialsProvider credentialsProvider;
        
        protected IDataWebServiceClient WebServiceClient { get; private set; }

        public DynamicBinder(IDataWebServiceClient webServiceClient, ICredentialsProvider credentialsProvider)
        {
            this.credentialsProvider = credentialsProvider;
            WebServiceClient = webServiceClient;
        }

        protected Credentials GetCredentials()
        {
            return credentialsProvider.GetCredentials();
        }
    }
}