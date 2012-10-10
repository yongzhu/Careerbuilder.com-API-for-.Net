using System.Collections.Generic;
using RestSharp;
using com.careerbuilder.api.models;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobRecommendationsRequest : GetRequest
    {
        protected string _jobDid = "";

        public JobRecommendationsRequest(string jobDid, string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
            _jobDid = jobDid;
        }

        public override string BaseURL
        {
            get { return "/v1/recommendations/forjob"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _jobDid);
            _request.RootElement = "RecommendJobResults";
            IRestResponse<List<RecommendJobResult>> response = _client.Execute<List<RecommendJobResult>>(_request);
            return response.Data;
        }
    }
}