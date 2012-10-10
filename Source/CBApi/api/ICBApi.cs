using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api
{
    public interface ICBApi
    {
        string CobrandCode { get; set; }
        string DevKey { get; set; }
        string SiteId { get; set; }
        string GetApplicationForm(string jobDid);
        BlankApplication GetBlankApplication(string jobDid);
        ICategoryRequest GetCategories();
        IEmployeeTypesRequest GetEmployeeTypes();
        Job GetJob(string jobDid);
        List<RecommendJobResult> GetRecommendationsForJob(string jobDid);
        List<RecommendJobResult> GetRecommendationsForUser(string externalId);
        IJobSearch JobSearch();
        ResponseJobReport JobReport(string jobDid);
        ResponseApplication SubmitApplication(Application app);
    }
}