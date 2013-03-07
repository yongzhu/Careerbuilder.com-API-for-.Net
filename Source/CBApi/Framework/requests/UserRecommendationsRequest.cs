using System;
using System.Collections.Generic;
using RestSharp;
using CBApi.Models;

namespace CBApi.Framework.Requests
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

        public override string BaseUrl
        {
            get { return "/v1/recommendations/foruser"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            _request.AddParameter("ExternalID", _ExternalID);
            _request.RootElement = "RecommendJobResults";
            base.BeforeRequest();
            IRestResponse<List<RecommendJobResult>> response = _client.Execute<List<RecommendJobResult>>(_request);
            CheckForErrors(response);
            return response.Data;
        }
    }
}