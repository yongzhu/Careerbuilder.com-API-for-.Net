using System.Collections.Generic;
using com.careerbuilder.Properties;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.models.service;
using System;

namespace com.careerbuilder.api {
    public class CbApi : ICBApi {
        #region attributes
        protected APISettings _Settings = new APISettings();

        public string DevKey { 
            get {return _Settings.DevKey;}
            set { _Settings.DevKey = value; } 
        }
        public string CobrandCode {
            get { return _Settings.CobrandCode; }
            set { _Settings.CobrandCode = value; }
        }
        public string SiteId {
            get { return _Settings.SiteId; }
            set { _Settings.SiteId = value; }
        }

        #endregion

        #region construction and factories

        protected internal CbApi() {
            _Settings.TargetSite = new CareerBuilderCom();
            _Settings.DevKey = Settings.Default.DevKey;
        }

        protected internal CbApi(string key) {
            _Settings.TargetSite = new CareerBuilderCom();
            _Settings.DevKey = key;
        }

        protected internal CbApi(string key, string cobrandCode) {
            _Settings.TargetSite = new CareerBuilderCom();
            _Settings.DevKey = key;
            _Settings.CobrandCode = cobrandCode;
        }

        protected internal CbApi(string key, string cobrandCode, string siteid) {
            _Settings.TargetSite = new CareerBuilderCom();
            _Settings.DevKey = key;
            _Settings.CobrandCode = cobrandCode;
            _Settings.SiteId = siteid;
        }

        #endregion

        #region api calls
        /// <summary>
        /// Make a call to /auth/token
        /// </summary>
        /// <param name="clientId">20 character long external client ID.</param>
        /// <param name="clientSecret">64 character long external client secret.</param>
        /// <param name="code">20 character long OAuth authorization grant code returned from auth/prompt redirection.</param>
        /// <param name="redirectUri">URL that was provided at the time of external client registration.</param>
        /// <returns></returns>
        AccessToken ICBApi.GetAccessToken(string clientId, string clientSecret, string code, string redirectUri) {
            var req = new AuthTokenRequest(clientId, clientSecret, code, redirectUri, _Settings);
            return req.GetAccessToken(); ;
        }
        
        /// <summary>
        /// Gets the Uri to redirect to for OAuth
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="redirectUri"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        Uri ICBApi.GetOAuthRedirectUri(string clientId, string redirectUri, string permissions) {
            var req = new OAuthRedirectBuilder(clientId, redirectUri, permissions, _Settings.TargetSite.Domain);
            return req.OAuthUri();
        }


        /// <summary>
        /// Make a call to /v1/categories
        /// </summary>
        /// <returns>A Category Request to query against</returns>
        public ICategoryRequest GetCategories() {
            return new CategoriesRequest(_Settings);
        }

        /// <summary>
        /// Make a call to /v1/employeetypes
        /// </summary>
        /// <returns>A Employee Request to query against</returns>
        public IEmployeeTypesRequest GetEmployeeTypes() {
            return new EmployeeTypesRequest(_Settings);
        }

        /// <summary>
        /// Make a call to /v1/application/blank
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public BlankApplication GetBlankApplication(string jobDid) {
            var req = new BlankApplicationRequest(jobDid, _Settings);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/application/form
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public string GetApplicationForm(string jobDid) {
            var req = new ApplicationFormRequest(jobDid, _Settings);
            return req.Retrieve();
        }

        /// <summary>
        /// Submit an application to /v1/application/submit
        /// </summary>
        /// <param name="app">The application being submited to careerbuilder</param>
        /// <returns></returns>
        public ResponseApplication SubmitApplication(Application app) {
            var req = new SubmitApplicationRequest(_Settings);
            return req.Submit(app);
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public Job GetJob(string jobDid) {
            var req = new JobRequest(jobDid, _Settings);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="JobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public List<RecommendJobResult> GetRecommendationsForJob(string jobDid) {
            var req = new JobRecommendationsRequest(jobDid, _Settings);
            return req.GetRecommendations();
        }

        /// <summary>
        /// make a call to /v1/recommendations/foruser
        /// </summary>
        /// <param name="externalId">The ID of the user that you wish to get recs for</param>
        /// <returns></returns>
        public List<RecommendJobResult> GetRecommendationsForUser(string externalId) {
            var req = new UserRecommendationsRequest(externalId, _Settings);
            return req.GetRecommendations();
        }

        /// <summary>
        /// Make a call to /v1/jobsearch
        /// </summary>
        /// <returns>A Job Request to query against</returns>
        public IJobSearch JobSearch() {
            return new JobSearchRequest(_Settings);
        }

        public ResponseJobReport JobReport(string jobDid) {
            var req = new JobReportRequest(jobDid, _Settings);
            return req.GetReport();
        }

        #endregion
    }
}