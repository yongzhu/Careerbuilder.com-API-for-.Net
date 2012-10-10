using System;
using System.Text;
using RestSharp;

namespace com.careerbuilder.api.framework.requests
{
    internal abstract class PostRequest
    {
        protected string _Domain = "";
        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest(Method.POST);

        protected PostRequest(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException("domain", "Please provide a valid domain name");
            }
            _Domain = domain;
        }

        public virtual string BaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual string PostRequestURL()
        {
            var url = new StringBuilder(20);
            url.Append("https://");
            url.Append(_Domain);
            url.Append(BaseUrl);
            return url.ToString();
        }

        protected virtual void BeforeRequest()
        {
            _client.BaseUrl = PostRequestURL();
            _request.RequestFormat = DataFormat.Xml;
        }
    }
}