using System;
using RestSharp;
using com.careerbuilder.api.models;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobRequest : GetRequest
    {
        protected string _jobDid = "";

        internal JobRequest(string jobDid, APISettings settings)
            : base(settings)
        {
            if (string.IsNullOrEmpty(jobDid))
            {
                throw new ArgumentNullException();
            }
            if (jobDid.Length >= 18 && jobDid.Length <= 20 &&
                jobDid.StartsWith("J", StringComparison.InvariantCultureIgnoreCase))
            {
                _jobDid = jobDid;
            }
            else
            {
                throw new ArgumentException("This does not look like a job did");
            }
        }

        public override string BaseUrl
        {
            get { return "/v1/job"; }
        }

        public Job Retrieve()
        {
            base.BeforeRequest();
            _request.AddParameter("DID", _jobDid);
            _request.RootElement = "Job";
            IRestResponse<Job> response = _client.Execute<Job>(_request);
            CheckForErrors(response);
            return response.Data;
        }
    }
}