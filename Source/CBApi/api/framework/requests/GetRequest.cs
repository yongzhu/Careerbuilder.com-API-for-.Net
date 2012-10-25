using System;
using System.Text;
using RestSharp;

namespace com.careerbuilder.api.framework.requests
{
    internal abstract class GetRequest
    {
        protected APISettings _Settings = null;

        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest();

        protected GetRequest(APISettings settings)
        {
            if (settings == null) {
                throw new ArgumentNullException("settings", "You must provide valid API Settings");
            }
            _Settings = settings;

            if (string.IsNullOrEmpty(settings.DevKey))
            {
                throw new ArgumentNullException("DevKey", "Please provide a valid developer key");
            }

            if (settings.TargetSite == null)
            {
                throw new ArgumentNullException("TargetSite", "Please provide a valid domain name");
            }

            if (settings.TargetSite != null && string.IsNullOrEmpty(settings.TargetSite.Domain)) {
                throw new ArgumentNullException("TargetSite", "Please provide a valid domain name");
            } 
        }

        public virtual string BaseURL
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual string GetRequestURL()
        {
            var url = new StringBuilder(20);
            url.Append("https://");
            url.Append(_Settings.TargetSite.Domain);
            url.Append(BaseURL);
            return url.ToString();
        }

        protected virtual void BeforeRequest()
        {
            _request.AddParameter("DeveloperKey", _Settings.DevKey);

            if (!string.IsNullOrEmpty(_Settings.CobrandCode))
            {
                _request.AddParameter("CoBrand", _Settings.CobrandCode);
            }

            if (!string.IsNullOrEmpty(_Settings.SiteId))
            {
                _request.AddParameter("SiteID", _Settings.SiteId);
            }
            _request.Timeout = _Settings.TimeoutMS;
            _client.BaseUrl = GetRequestURL();
        }
    }
}