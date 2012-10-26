using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api;
using com.careerbuilder.api.models.service;
using Tests.com.careerbuilder.api.models.requests;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class GetRequestTest
    {
        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDevKey()
        {
            try
            {
                var request = new GetRequestStub("", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDevKey()
        {
            try
            {
                var request = new GetRequestStub(null, "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDomain()
        {
            try
            {
                var request = new GetRequestStub("DevKey", "", "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDomain()
        {
            try
            {
                var request = new GetRequestStub("DevKey", null, "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_SetsDevKey()
        {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("DevKey", request.DevKey);
        }

        [TestMethod]
        public void Constructor_SetsDomain()
        {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("api.careerbuilder.com", request.Domain);
        }

        [TestMethod]
        public void Constructor_SetsCobrand()
        {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "cobrandcode", "");
            Assert.AreEqual("cobrandcode", request.CobrandCode);
        }

        [TestMethod]
        public void Constructor_SetsSiteID()
        {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "SiteID");
            Assert.AreEqual("SiteID", request.SiteID);
        }

        [TestMethod]
        public void BaseURL_ThrowsException_IfNotOverridden()
        {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "SiteID");
            try
            {
                string temp = request.BaseURL;
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (NotImplementedException));
            }
        }

        [TestMethod]
        public void BeforeRequest_SetsDevKey_AndDomain_AndCobrand_AndSiteID()
        {
            //Setup
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "this is a cobrand", "this is a siteid");

            //Mock crap
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("CoBrand", "this is a cobrand"));
            restReq.Setup(x => x.AddParameter("SiteID", "this is a siteid"));

            var restClient = new Mock<IRestClient>();
            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            try
            {
                request.RunBeforeGet();
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                restReq.VerifyAll();
                Assert.IsInstanceOfType(ex, typeof (NotImplementedException));
            }
        }
    }

    internal class GetRequestStub : GetRequest
    {
        public GetRequestStub(string key, string domain, string cobrand, string siteid)
            : base(new APISettings() { DevKey = key, CobrandCode = cobrand, SiteId = siteid, TargetSite = new TargetSiteMock(domain) }) {
        }

        public string DevKey
        {
            get { return _Settings.DevKey; }
        }

        public string Domain
        {
            get { return _Settings.TargetSite.Domain; }
        }

        public string CobrandCode
        {
            get { return _Settings.CobrandCode; }
        }

        public string SiteID
        {
            get { return _Settings.SiteId; }
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

        public void RunBeforeGet()
        {
            BeforeRequest();
        }
    }
}