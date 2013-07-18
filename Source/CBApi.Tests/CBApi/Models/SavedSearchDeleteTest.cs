using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Deserializers;
using CBApi.Models;
using System.IO;
using System.Xml.Linq;

namespace Tests.CBApi.models {
    [TestClass]
    public class SavedSearchDeleteTest
    {
        [TestMethod]
        [DeploymentItem("testdata\\SavedSearchDeleteResult.xml")]
        public void DeserializationWorks_WhenPassedRightXML() {
            var xmlpath = Path.Combine(Environment.CurrentDirectory, "SavedSearchDeleteResult.xml");
            var doc = XDocument.Load(xmlpath);

            var xml = new XmlDeserializer();
            var output = xml.Deserialize<RequestSavedSearchDelete>(new RestResponse() { Content = doc.ToString() });

            Assert.IsNotNull(output);
            Assert.AreEqual("WD******************", output.DeveloperKey);
            Assert.AreEqual("b5**************************************************************", output.ExternalID);
            Assert.AreEqual("ec**************************************************************", output.ExternalUserID);
            Assert.AreEqual("US", output.HostSite);
            Assert.AreEqual("Success", output.Status);
        }
    }
}
