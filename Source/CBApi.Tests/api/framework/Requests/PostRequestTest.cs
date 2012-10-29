using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using Tests.com.careerbuilder.api.models.requests;

namespace Tests.com.careerbuilder.api.framework.requests {
    [TestClass]
    public class PostRequestTest {
        [TestMethod]
        public void BeforeRequest_SetsURL_SetsFormat_SetsTimeout() {
            //Setup
            var request = new PostRequestStub("DevKey", "api.careerbuilder.com", "this is a cobrand", "this is a siteid",12345);

            //Mock crap
            var restClient = new Mock<IRestClient>();
            var restReq = new Mock<IRestRequest>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/Exammple");

            restReq.SetupSet(x => x.RequestFormat = DataFormat.Xml);
            restReq.SetupSet(x => x.Timeout = 12345);

            
            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            request.RunBeforeRequest();
            restReq.VerifyAll();
        }
    }
}