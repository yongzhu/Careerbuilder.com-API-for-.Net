using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RestSharp;

namespace com.careerbuilder.api.framework.requests
{
    internal abstract class PostRequest
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

        public virtual string BaseUrl
        {
            get { throw new NotImplementedException(); }
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
        }

        protected virtual void CheckForErrors(IRestResponse response) {
            if (!string.IsNullOrEmpty(response.Content)) {
                var errors = new List<string>();
                var xml = new XmlDocument();
                xml.LoadXml(response.Content);
                foreach (XmlNode item in xml.SelectNodes("//Error")) {
                    if (!string.IsNullOrEmpty(item.InnerText)) {
                        errors.Add(item.InnerText);
                    }
                }
                if (errors.Count > 0) {
                    throw new APIException(errors[0], errors);
                }
            }

            if (response.ResponseStatus == ResponseStatus.TimedOut) {
                throw new APITimeoutException(response.ErrorMessage);
            } else if (response.ResponseStatus != ResponseStatus.None) {
                throw new APIException(response.ErrorMessage);
            }
        }
    }
}