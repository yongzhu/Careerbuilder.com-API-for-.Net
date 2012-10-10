using RestSharp;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobReportRequest : GetRequest
    {
        private readonly string _jobDid = "";

        public JobReportRequest(string jobDid, string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
            _jobDid = jobDid;
        }

        public override string BaseURL
        {
            get { return "/v1/jobreport"; }
        }

        public ResponseJobReport GetReport()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _jobDid);
            IRestResponse<ResponseJobReport> response = _client.Execute<ResponseJobReport>(_request);
            return response.Data;
        }
    }
}