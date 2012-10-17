using System;
using System.Collections.Generic;
using com.careerbuilder;
using com.careerbuilder.api;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.models.service;

namespace CBApiCosoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICBApi svc = API.GetInstance("WDTY17R6R231BWMK4XV6");

            var token = svc.GetAccessToken("EC18VBEK3JWI3NDN4892", "XI0Q3QP6fbyji7uix5VCOr3RE1a8Ha8HvobacllNSVg3o3TD5vwbVKu4rz0cz7EU", "AGHS5YX77PV2BXFXVCB2", "localhost%3a5787%2ftoken%2f%3fnextPage%3d%2fmycareerbuilder%2f");

            ResponseJobReport jobReport = svc.JobReport("J3J67S75826K34DRBMB");


            //Make a call to https://api.careerbuilder.com/v2/categories
            List<Category> codes = svc.GetCategories()
                .WhereCountryCode(CountryCode.US)
                .ListAll();
            foreach (Category code in codes)
            {
                Console.WriteLine(code.Code);
            }

            //Make a call to https://api.careerbuilder.com/v2/employeetypes
            List<EmployeeType> emps = svc.GetEmployeeTypes()
                .WhereCountryCode(CountryCode.US)
                .ListAll();
            foreach (EmployeeType emp in emps)
            {
                Console.WriteLine(emp.Code);
            }

            //Search for Jobs
            ResponseJobSearch search = svc.JobSearch()
                .WhereKeywords("Sales")
                .WhereLocation("Atlanta,GA")
                .WhereCountryCode(CountryCode.US)
                .OrderBy(OrderByType.Title)
                .Ascending()
                .Search();
            List<JobSearchResult> jobs = search.Results;
            foreach (JobSearchResult item in jobs)
            {
                Console.WriteLine(item.JobTitle);
            }

            //Make a call to https://api.careerbuilder.com/v2/recommendations/forjob
            List<RecommendJobResult> jobRecs = svc.GetRecommendationsForJob(jobs[0].DID);
            foreach (RecommendJobResult item in jobRecs)
            {
                Console.WriteLine(item.Title);
            }

            //Make a call to https://api.careerbuilder.com/v2/job
            Job myJob = svc.GetJob(jobs[0].DID);
            Console.WriteLine(myJob.JobTitle);

            //Make a call to https://api.careerbuilder.com/v2/application/blank
            BlankApplication myApp = svc.GetBlankApplication(jobs[0].DID);

            //Make a call to https://api.careerbuilder.com/v2/application/submit in test mode
            myApp.Test = true;
            ResponseApplication tempResponse = svc.SubmitApplication(myApp);
            Console.WriteLine(tempResponse.ApplicationStatus);

            //Make a call to https://api.careerbuilder.com/v2/application/form
            string form = svc.GetApplicationForm(jobs[0].DID);
            Console.WriteLine(form);
        }
    }
}