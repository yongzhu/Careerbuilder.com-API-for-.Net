using CBApi;
using CBApi.Framework.Requests;
using CBApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using Tests.CBApi.models.requests;
using Tests.CBApi.models.service;

namespace Tests.CBApi.framework.requests
{
    [TestClass]
    public class SavedSearchCreateRequestTest
    {
        [TestMethod]
        public void Submit_PerformsCorrectRequest()
        {
            //setup
            var request = new SavedSearchCreateRequestStub("DevKey", "api.careerbuilder.com", "", "", 12345);
            var dummyApp = new SavedSearchCreate();
            dummyApp.HostSite = "US";
            dummyApp.SearchName = "lotsloc";
            dummyApp.IsDailyEmail = "none";
            dummyApp.ExternalUserID = "Nicholas.Busby.Test@CareerBuilder.com";
            dummyApp.DeveloperKey = "WDJ16BN6CQB69FP18Y8F";
            dummyApp.Parameters = new SearchParameters();
            dummyApp.Parameters.Radius = 30;
            dummyApp.Parameters.PayHigh = 70;
            dummyApp.Parameters.PayLow = 40;
            dummyApp.Parameters.PostedWithin = 30;
            dummyApp.Parameters.PayInfoOnly = false;
            dummyApp.Parameters.Location = "Chicago, Il, Atlanta, Ga, New York, Ny";
            dummyApp.Parameters.OrderDirection = "ascending";
            dummyApp.Parameters.SpecificEducation = false;
            dummyApp.Parameters.ExcludeNational = false;
            dummyApp.Parameters.OrderBy = "Pay";

            //Mock
            var response = new RestResponse<SavedSearchCreateResponse> { Data = new SavedSearchCreateResponse(), ResponseStatus = ResponseStatus.Completed };
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddBody(dummyApp));

            

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v2/SavedSearch/Create");
            restClient.Setup(x => x.Execute<SavedSearchCreateResponse>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assertions
            SavedSearchCreateResponse rest = request.Submit(dummyApp);
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }
}
