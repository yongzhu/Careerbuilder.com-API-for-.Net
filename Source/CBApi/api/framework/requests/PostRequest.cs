using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RestSharp;

namespace com.careerbuilder.api.framework.requests
{
    public abstract class PostRequest
    {
        private APISettings _Settings = null;
        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest(Method.POST);

        protected PostRequest(APISettings settings)
        {
            if (settings == null) {
                throw new ArgumentNullException("settings", "You must provide valid API settings");
            }
            _Settings = settings;
            if (_Settings.TargetSite == null)
            {
                throw new ArgumentNullException("domain", "Please provide a valid domain name");
            }
        }

        public abstract string BaseUrl { get;}

        protected virtual string PostRequestURL()
        {
            var url = new StringBuilder(20);
            url.Append("https://");
            url.Append(_Settings.TargetSite.Domain);
            url.Append(BaseUrl);
            return url.ToString();
        }

        protected virtual void BeforeRequest()
        {
            _client.BaseUrl = PostRequestURL();
            _request.RequestFormat = DataFormat.Xml;
            _request.Timeout = _Settings.TimeoutMS;
        }

        protected virtual void CheckForErrors(IRestResponse response) {
            ErrorParser.CheckForErrors(response);
        }
    }
}