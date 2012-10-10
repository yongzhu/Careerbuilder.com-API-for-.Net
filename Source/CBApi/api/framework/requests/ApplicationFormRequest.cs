using System;
using RestSharp;

namespace com.careerbuilder.api.framework.requests
{
    internal class ApplicationFormRequest : GetRequest
    {
        protected string JobDid = "";

        public ApplicationFormRequest(string jobDid, string key, string domain)
            : base(key, domain, "", "")
        {
            if (string.IsNullOrEmpty(jobDid))
            {
                throw new ArgumentNullException();
            }
            
            if (jobDid.Length >= 18 && jobDid.Length <= 20 &&
                     jobDid.StartsWith("J", StringComparison.InvariantCultureIgnoreCase))
            {
                JobDid = jobDid;
            }
            else
            {
                throw new ArgumentException("This does not look like a job did");
            }
        }

        public override string BaseURL
        {
            get { return "/v1/application/form"; }
        }

        public string Retrieve()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", JobDid);
            IRestResponse response = _client.Execute(_request);
            return response.Content;
        }
    }
}