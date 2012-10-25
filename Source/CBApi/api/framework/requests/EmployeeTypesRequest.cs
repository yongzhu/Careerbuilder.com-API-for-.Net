using System.Collections.Generic;
using RestSharp;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class EmployeeTypesRequest : GetRequest, IEmployeeTypesRequest
    {
        protected string _countryCode = "US";

        public EmployeeTypesRequest(APISettings settings)
            : base(settings)
        {
        }

        public override string BaseURL
        {
            get { return "/v1/employeetypes"; }
        }

        #region IEmployeeTypesRequest Members

        public IEmployeeTypesRequest WhereCountryCode(CountryCode value)
        {
            _countryCode = value.ToString();
            return this;
        }

        public IEmployeeTypesRequest WhereHostSite(HostSite value)
        {
            _countryCode = value.ToString();
            return this;
        }

        public List<EmployeeType> ListAll()
        {
            base.BeforeRequest();
            _request.AddParameter("CountryCode", _countryCode);
            _request.RootElement = "EmployeeTypes";
            IRestResponse<List<EmployeeType>> response = _client.Execute<List<EmployeeType>>(_request);
            return response.Data;
        }

        #endregion
    }
}