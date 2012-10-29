using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using Tests.com.careerbuilder.api.models.requests;

namespace Tests.com.careerbuilder.api.framework.requests {
    [TestClass]
    public class GetRequestTest {
        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDevKey() {
            try {
                var request = new GetRequestStub("", "api.careerbuilder.com", "", "");
                Assert.Fail();
            } catch (ArgumentNullException ex) {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDevKey() {
            try {
                var request = new GetRequestStub(null, "api.careerbuilder.com", "", "");
                Assert.Fail();
            } catch (ArgumentNullException ex) {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDomain() {
            try {
                var request = new GetRequestStub("DevKey", "", "", "");
                Assert.Fail();
            } catch (ArgumentNullException ex) {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDomain() {
            try {
                var request = new GetRequestStub("DevKey", null, "", "");
                Assert.Fail();
            } catch (ArgumentNullException ex) {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_SetsDevKey() {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("DevKey", request.DevKey);
        }

        [TestMethod]
        public void Constructor_SetsDomain() {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("api.careerbuilder.com", request.Domain);
        }

        [TestMethod]
        public void Constructor_SetsCobrand() {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "cobrandcode", "");
            Assert.AreEqual("cobrandcode", request.CobrandCode);
        }

        [TestMethod]
        public void Constructor_SetsSiteID() {
            var request = new GetRequestStub("DevKey", "api.careerbuilder.com", "", "SiteID");
            Assert.AreEqual("SiteID", request.SiteID);
        }

        [TestMethod]
        public void BeforeRequest_SetsDevKey_AndDomain_AndCobrand_AndSiteID() {
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
            request.RunBeforeGet();
            restReq.VerifyAll();
        }
    }
}