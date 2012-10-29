using com.careerbuilder.api;
using com.careerbuilder.api.framework.requests;
using RestSharp;
using Tests.com.careerbuilder.api.models.service;

namespace Tests.com.careerbuilder.api.models.requests {
    internal class PostRequestStub : PostRequest {
        private string _BaseURL = "/Exammple";
        public PostRequestStub(string key, string domain, string cobrand, string siteid,int timeout)
            : base(new APISettings() { DevKey = key, CobrandCode = cobrand, SiteId = siteid, TargetSite = new TargetSiteMock(domain),TimeoutMS = timeout }) {
        }

        public override string BaseUrl {
            get { return _BaseURL; }
        }

        public string SetBaseUrl {
            set { _BaseURL = value; }
        }

        public IRestClient Client {
            get { return _client; }
            set { _client = value; }
        }

        public IRestRequest Request {
            get { return _request; }
            set { _request = value; }
        }

        public void RunBeforeRequest() {
            BeforeRequest();
        }
    }
}
