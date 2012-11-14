using System.Collections.Generic;
using RestSharp;
using CBApi.Models;

namespace CBApi.Framework.Requests
{
    internal class JobRecommendationsRequest : GetRequest
    {
        protected string _jobDid = "";

        public JobRecommendationsRequest(string jobDid, APISettings settings)
            : base(settings)
        {
            _jobDid = jobDid;
        }

        public override string BaseUrl
        {
            get { return "/v1/recommendations/forjob"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _jobDid);
            _request.RootElement = "RecommendJobResults";
            IRestResponse<List<RecommendJobResult>> response = _client.Execute<List<RecommendJobResult>>(_request);
            CheckForErrors(response);
            return response.Data;
        }
    }
}