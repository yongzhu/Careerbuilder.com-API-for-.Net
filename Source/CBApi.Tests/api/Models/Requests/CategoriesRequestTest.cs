using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class CategoriesTest
    {
        [TestMethod]
        public void Constructor_DefaultsToUSCountryCode()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("US", request.CountryCode);
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("https://api.careerbuilder.com/v1/categories", request.RequestURL);
        }

        [TestMethod]
        public void WhereCountryCode_ReturnsCategoryRequest()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.IsInstanceOfType(request.WhereCountryCode(CountryCode.SE), typeof (ICategoryRequest));
        }

        [TestMethod]
        public void WhereCountryCode_SetsCountryCode()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            request.WhereCountryCode(CountryCode.SE);
            Assert.AreEqual("SE", request.CountryCode);
        }

        [TestMethod]
        public void WhereHostSite_ReturnsCategoryRequest()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.IsInstanceOfType(request.WhereHostSite(HostSite.EU), typeof (ICategoryRequest));
        }

        [TestMethod]
        public void WhereHostSite_SetsCountryCode()
        {
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");
            request.WhereHostSite(HostSite.EU);
            Assert.AreEqual("EU", request.CountryCode);
        }

        [TestMethod]
        public void ListAll_PerformsCorrectRequest()
        {
            //Setup
            var request = new CategoriesStub("DevKey", "api.careerbuilder.com", "", "");

            //Mock crap
            var response = new RestResponse<List<Category>> {Data = new List<Category>()};

            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("CountryCode", "NL"));
            restReq.SetupSet(x => x.RootElement = "Categories");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/categories");
            restClient.Setup(x => x.Execute<List<Category>>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            List<Category> cats = request.WhereCountryCode(CountryCode.NL).ListAll();
            Assert.IsTrue(cats.Count == 0);
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    internal class CategoriesStub : CategoriesRequest
    {
        public CategoriesStub(string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
        }

        public string DevKey
        {
            get { return _DevKey; }
        }

        public string Domain
        {
            get { return _Domain; }
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