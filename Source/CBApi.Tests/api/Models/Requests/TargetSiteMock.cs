using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api.models.service;

namespace Tests.com.careerbuilder.api.models.requests {
    public class TargetSiteMock : TargetSite {
        public TargetSiteMock(string domain) {
            _Domain = domain;
        }
    }
}
