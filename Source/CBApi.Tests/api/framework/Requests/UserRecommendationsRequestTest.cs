using com.careerbuilder.api.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using Tests.com.careerbuilder.api.models.requests;

namespace Tests.com.careerbuilder.api.framework.requests
{
    [TestClass]
    public class UserRecommendationsRequestTest
    {
        [TestMethod]
        public void Constructor_SetsExternalID()
        {
            var request = new UserReqStub("ExternalID", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("ExternalID", request.ExternalID);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedNullOrEmpty()
        {
            try
            {
                var request = new UserReqStub(null, "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }

            try
            {
                var request2 = new UserReqStub("", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof (ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            var request = new UserReqStub("ExternalID", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("https://api.careerbuilder.com/v1/recommendations/foruser", request.RequestURL);
        }

        [TestMethod]
        public void GetRecommendations_PerformsCorrectRequest()
        {
            //Setup
            var request = new UserReqStub("ExternalID", "DevKey", "api.careerbuilder.com", "", "");

            //Mock crap
            var response = new RestResponse<List<RecommendJobResult>> {Data = new List<RecommendJobResult>()};

            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("ExternalID", "ExternalID"));
            restReq.SetupSet(x => x.RootElement = "RecommendJobResults");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/recommendations/foruser");
            restClient.Setup(x => x.Execute<List<RecommendJobResult>>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            List<RecommendJobResult> resp = request.GetRecommendations();
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }
}