using System;
using System.Collections.Generic;
using RestSharp;
using com.careerbuilder.api.models;

namespace com.careerbuilder.api.framework.requests
{
    internal class UserRecommendationsRequest : GetRequest
    {
        protected string _ExternalID = "";

        public UserRecommendationsRequest(string externalID, APISettings settings)
            : base(settings)
        {
            if (!string.IsNullOrEmpty(externalID))
            {
                _ExternalID = externalID;
            }
            else
            {
                throw new ArgumentNullException("externalID", "ExternalID is requried");
            }
        }

        public override string BaseURL
        {
            get { return "/v1/recommendations/foruser"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            base.BeforeRequest();
            _request.AddParameter("ExternalID", _ExternalID);
            _request.RootElement = "RecommendJobResults";
            IRestResponse<List<RecommendJobResult>> response = _client.Execute<List<RecommendJobResult>>(_request);
            return response.Data;
        }
    }
}