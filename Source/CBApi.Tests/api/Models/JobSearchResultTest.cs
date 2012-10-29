using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using System.Xml;
using System.Xml.Linq;
using com.careerbuilder.api.models.responses;
using System.IO;

namespace Tests.com.careerbuilder.api.models {
    [TestClass]
    public class JobSearchResultTest {
        [TestMethod]
        [DeploymentItem("api\\Models\\ResponseJobSearch.xml")]
        public void DeserializationWorks_WhenPassedRightXML() {
            var xmlpath = Path.Combine(Environment.CurrentDirectory,"ResponseJobSearch.xml");
            var doc = XDocument.Load(xmlpath);

            var xml = new XmlDeserializer();
            var output = xml.Deserialize<ResponseJobSearch>(new RestResponse() { Content = doc.ToString() });

            Assert.IsNotNull(output.Results);
            Assert.AreEqual(25, output.Results.Count);
            Assert.AreEqual("Direct Sales Recruiting, LLC", output.Results[0].Company);
            Assert.AreEqual("c35x165rs82x1bnbbc", output.Results[0].CompanyDID);
            Assert.AreEqual("http://www.careerbuilder.com/Jobs/Company/C35X165RS82X1BNBBC/Direct-Sales-Recruiting-LLC/?sc_cmp1=13_JobRes_ComDet", output.Results[0].CompanyDetailsURL);
            Assert.AreEqual("JHM0LH6LPCGLF3FR3ZB", output.Results[0].DID);
            Assert.AreEqual("41-4011.00", output.Results[0].OnetCode);
            Assert.AreEqual("Full-Time", output.Results[0].EmploymentType);
            Assert.AreEqual("http://api.careerbuilder.com/v1/joblink?TrackingID=DLR0T71H&DID=JHM0LH6LPCGLF3FR3ZB", output.Results[0].JobDetailsURL);
            Assert.AreEqual("http://api.careerbuilder.com/v1/job?DID=JHM0LH6LPCGLF3FR3ZB&DeveloperKey=WXXXXXXXXXXXXXXXXXX", output.Results[0].JobServiceURL);
            Assert.AreEqual("TN - Chattanooga", output.Results[0].Location);
            Assert.AreEqual(35.04644f, output.Results[0].LocationLatitude);
            Assert.AreEqual(-85.30946f, output.Results[0].LocationLongitude);
            Assert.AreEqual("10/28/2012", output.Results[0].PostedDate);
            Assert.AreEqual("$70k - $80k/year", output.Results[0].Pay);
            Assert.AreEqual("http://www.careerbuilder.com/jobseeker/jobs/recommendedjobs.aspx?ipath=JELO&job_did=JHM0LH6LPCGLF3FR3ZB", output.Results[0].SimilarJobsURL);
            Assert.AreEqual("Medical Sales-Tissue Graft/Biologics-Wound Care", output.Results[0].JobTitle);
            Assert.AreEqual("http://emj.icbdr.com/MediaManagement/QS/I8F50C63D7B6SGPDXQS.gif", output.Results[0].CompanyImageURL);


        }
    }
}
