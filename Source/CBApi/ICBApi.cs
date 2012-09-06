using com.careerbuilder.api.models;
using System;
using System.Collections;
using System.Collections.Generic;
using com.careerbuilder.api.models.responses;
namespace com.careerbuilder.api
{
    public interface ICBApi
    {
        string CobrandCode { get; set; }
        string DevKey { get; set; }
        string GetApplicationForm(string jobDID);
        BlankApplication GetBlankApplication(string jobDID);
        ICategoryRequest GetCategories();
        IEmployeeTypesRequest GetEmployeeTypes();
        Job GetJob(string jobDID);
        List<RecommendJobResult> GetRecommendationsForJob(string jobDID);
        List<RecommendJobResult> GetRecommendationsForUser(string externalID);
        IJobSearch JobSearch();
        ResponseJobReport JobReport(string jobDID);
        string SiteID { get; set; }
        ResponseApplication SubmitApplication(com.careerbuilder.api.models.Application app);
    }
}
