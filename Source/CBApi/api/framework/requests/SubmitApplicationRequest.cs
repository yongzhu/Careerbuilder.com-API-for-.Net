using RestSharp;
using com.careerbuilder.api.models;

namespace com.careerbuilder.api.framework.requests
{
    internal class SubmitApplicationRequest : PostRequest
    {
        public SubmitApplicationRequest(APISettings settings) : base(settings)
        {
        }

        public override string BaseUrl
        {
            get { return "/v1/application/submit"; }
        }

        public ResponseApplication Submit(RequestApplication app)
        {
            base.BeforeRequest();
            _request.AddBody(app);
            IRestResponse<ResponseApplication> response = _client.Execute<ResponseApplication>(_request);
            CheckForErrors(response);
            return response.Data;
        }
    }
}