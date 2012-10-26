using System.Collections.Generic;
using RestSharp;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class CategoriesRequest : GetRequest, ICategoryRequest
    {
        protected string _countryCode = "US";

        public CategoriesRequest(APISettings settings)
            : base(settings)
        {
        }

        public override string BaseURL
        {
            get { return "/v1/categories"; }
        }

        #region ICategoryRequest Members

        public ICategoryRequest WhereCountryCode(CountryCode value)
        {
            _countryCode = value.ToString();
            return this;
        }

        public ICategoryRequest WhereHostSite(HostSite value)
        {
            _countryCode = value.ToString();
            return this;
        }

        public List<Category> ListAll()
        {
            base.BeforeRequest();
            _request.AddParameter("CountryCode", _countryCode);
            _request.RootElement = "Categories";
            IRestResponse<List<Category>> response = _client.Execute<List<Category>>(_request);
            CheckForErrors(response);
            return response.Data;
        }

        #endregion
    }
}