using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using Tests.com.careerbuilder.api.models.requests;
using com.careerbuilder.api;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class EmployeeTypesTest
    {
        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.AreEqual("https://api.careerbuilder.com/v1/employeetypes", request.RequestURL);
        }

        [TestMethod]
        public void WhereCountryCode_ReturnsCategoryRequest()
        {
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.IsInstanceOfType(request.WhereCountryCode(CountryCode.SE), typeof (IEmployeeTypesRequest));
        }

        [TestMethod]
        public void WhereCountryCode_SetsCountryCode()
        {
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            request.WhereCountryCode(CountryCode.SE);
            Assert.AreEqual("SE", request.CountryCode);
        }

        [TestMethod]
        public void WhereHostSite_ReturnsCategoryRequest()
        {
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.IsInstanceOfType(request.WhereHostSite(HostSite.EU), typeof (IEmployeeTypesRequest));
        }

        [TestMethod]
        public void WhereHostSite_SetsCountryCode()
        {
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            request.WhereHostSite(HostSite.EU);
            Assert.AreEqual("EU", request.CountryCode);
        }

        [TestMethod]
        public void ListAll_PerformsCorrectRequest()
        {
            //Setup
            var request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");

            //Mock crap
            var response = new RestResponse<List<EmployeeType>> {Data = new List<EmployeeType>()};

            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("CountryCode", "NL"));
            restReq.SetupSet(x => x.RootElement = "EmployeeTypes");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/employeetypes");
            restClient.Setup(x => x.Execute<List<EmployeeType>>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            List<EmployeeType> cats = request.WhereCountryCode(CountryCode.NL).ListAll();
            Assert.IsTrue(cats.Count == 0);
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    internal class EmployeeTypesStub : EmployeeTypesRequest
    {
        public EmployeeTypesStub(string key, string domain)
            : base(new APISettings() { DevKey = key, CobrandCode = "", SiteId = "", TargetSite = new TargetSiteMock(domain) })
        {
        }

        public string DevKey
        {
            get { return _Settings.DevKey; }
        }

        public string Domain
        {
            get { return _Settings.TargetSite.Domain; }
        }

        public string CountryCode
        {
            get { return _countryCode; }
        }

        public string RequestURL
        {
            get { return base.GetRequestURL(); }
        }

        public IRestClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public IRestRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }
    }
}