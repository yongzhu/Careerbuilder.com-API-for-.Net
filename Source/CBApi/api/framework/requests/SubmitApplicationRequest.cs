using RestSharp;
using com.careerbuilder.api.models;

namespace com.careerbuilder.api.framework.requests
{
    internal class SubmitApplicationRequest : PostRequest
    {
        public SubmitApplicationRequest(string domain) : base(domain)
        {
        }

        public override string BaseUrl
        {
            get { return "/v1/application/submit"; }
        }

        public ResponseApplication Submit(Application app)
        {
            base.BeforeRequest();
            _request.AddBody(app);
            IRestResponse<ResponseApplication> response = _client.Execute<ResponseApplication>(_request);
            return response.Data;
        }
    }
}