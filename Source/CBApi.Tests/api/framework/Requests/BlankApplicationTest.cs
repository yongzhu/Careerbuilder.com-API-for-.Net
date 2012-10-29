using com.careerbuilder.api;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using Tests.com.careerbuilder.api.models.requests;
using Tests.com.careerbuilder.api.models.service;

namespace Tests.com.careerbuilder.api.framework.requests
{
    [TestClass]
    public class BlankApplicationTest
    {
        [TestMethod]
        public void Constructor_SetsJobDID()
        {
            var request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("JXXXXXXXXXXXXXXXXXX", request.JobDID);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedNullOrEmpty()
        {
            try
            {
                var request = new BlankAppStub(null, "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }

            try
            {
                var request = new BlankAppStub("", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedBadJobDID()
        {
            try
            {
                var request = new BlankAppStub("UXXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentException));
            }

            try
            {
                var request = new BlankAppStub("JXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentException));
            }
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            var request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("https://api.careerbuilder.com/v1/application/blank", request.RequestURL);
        }

        [TestMethod]
        public void Retrieve_PerformsCorrectRequest()
        {
            //Setup
            var request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");

            //Mock crap
            var response = new RestResponse<BlankApplication> {Data = new BlankApplication()};

            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("JobDID", "JXXXXXXXXXXXXXXXXXX"));
            restReq.SetupSet(x => x.RootElement = "BlankApplication");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/application/blank");
            restClient.Setup(x => x.Execute<BlankApplication>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            BlankApplication resp = request.Retrieve();
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }
}