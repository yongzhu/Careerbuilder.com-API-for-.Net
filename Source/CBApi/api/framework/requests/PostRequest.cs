using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RestSharp;
using com.careerbuilder.api.framework.events;

namespace com.careerbuilder.api.framework.requests
{
    public abstract class PostRequest
    {
        private APISettings _Settings = null;
        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest(Method.POST);
        protected BeforeRequestEvent _BeforeRequestEvent = delegate { };
        protected AfterRequestEvent _AfterRequestEvent = delegate { };

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

        internal event BeforeRequestEvent OnBeforeRequest {
            add { _BeforeRequestEvent += value; }
            remove { _BeforeRequestEvent += value; }
        }

        internal event AfterRequestEvent OnAfterRequest {
            add { _AfterRequestEvent += value; }
            remove { _AfterRequestEvent += value; }
        }

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
            if (!string.IsNullOrEmpty(_Settings.TargetSite.Host)) {
                _request.AddHeader("Host", _Settings.TargetSite.Host);
            }
            _BeforeRequestEvent(new RequestEventData(_client, _request, null));
        }

        protected virtual void CheckForErrors(IRestResponse response) {
            ErrorParser.CheckForErrors(response);
        }
    }
}