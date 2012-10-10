using System.Collections.Generic;
using com.careerbuilder.Properties;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api
{
    public class CbApi : ICBApi
    {
        #region attributes

        protected TargetSite TargetSite = null;
        public string DevKey { get; set; }
        public string CobrandCode { get; set; } //If you are a careerbuilder partner you can set these tracking codes
        public string SiteId { get; set; } //Otherwise leave these two parameters alone

        #endregion

        #region construction and factories

        protected internal CbApi()
        {
            TargetSite = new CareerBuilderCom();
            DevKey = Settings.Default.DevKey;
        }

        protected internal CbApi(string key)
        {
            TargetSite = new CareerBuilderCom();
            DevKey = key;
        }

        protected internal CbApi(string key, string cobrandCode)
        {
            TargetSite = new CareerBuilderCom();
            DevKey = key;
            CobrandCode = cobrandCode;
        }

        protected internal CbApi(string key, string cobrandCode, string siteid)
        {
            TargetSite = new CareerBuilderCom();
            DevKey = key;
            CobrandCode = cobrandCode;
            SiteId = siteid;
        }

        #endregion

        #region api calls

        /// <summary>
        /// Make a call to /v1/categories
        /// </summary>
        /// <returns>A Category Request to query against</returns>
        public ICategoryRequest GetCategories()
        {
            return new CategoriesRequest(DevKey, TargetSite.Domain, CobrandCode, SiteId);
        }

        /// <summary>
        /// Make a call to /v1/employeetypes
        /// </summary>
        /// <returns>A Employee Request to query against</returns>
        public IEmployeeTypesRequest GetEmployeeTypes()
        {
            return new EmployeeTypesRequest(DevKey, TargetSite.Domain, CobrandCode, SiteId);
        }

        /// <summary>
        /// Make a call to /v1/application/blank
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public BlankApplication GetBlankApplication(string jobDid)
        {
            var req = new BlankApplicationRequest(jobDid, DevKey, TargetSite.Domain, CobrandCode, SiteId);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/application/form
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public string GetApplicationForm(string jobDid)
        {
            var req = new ApplicationFormRequest(jobDid, DevKey, TargetSite.Domain);
            return req.Retrieve();
        }

        /// <summary>
        /// Submit an application to /v1/application/submit
        /// </summary>
        /// <param name="app">The application being submited to careerbuilder</param>
        /// <returns></returns>
        public ResponseApplication SubmitApplication(Application app)
        {
            var req = new SubmitApplicationRequest(TargetSite.Domain);
            return req.Submit(app);
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public Job GetJob(string jobDid)
        {
            var req = new JobRequest(jobDid, DevKey, TargetSite.Domain, CobrandCode, SiteId);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public List<RecommendJobResult> GetRecommendationsForJob(string jobDid)
        {
            var req = new JobRecommendationsRequest(jobDid, DevKey, TargetSite.Domain, CobrandCode, SiteId);
            return req.GetRecommendations();
        }

        /// <summary>
        /// make a call to /v1/recommendations/foruser
        /// </summary>
        /// <param name="externalId">The ID of the user that you wish to get recs for</param>
        /// <returns></returns>
        public List<RecommendJobResult> GetRecommendationsForUser(string externalId)
        {
            var req = new UserRecommendationsRequest(externalId, DevKey, TargetSite.Domain, CobrandCode, SiteId);
            return req.GetRecommendations();
        }

        /// <summary>
        /// Make a call to /v1/jobsearch
        /// </summary>
        /// <returns>A Job Request to query against</returns>
        public IJobSearch JobSearch()
        {
            return new JobSearchRequest(DevKey, TargetSite.Domain, CobrandCode, SiteId);
        }

        public ResponseJobReport JobReport(string jobDid)
        {
            var req = new JobReportRequest(jobDid, DevKey, TargetSite.Domain, CobrandCode, SiteId);
            return req.GetReport();
        }

        #endregion
    }
}