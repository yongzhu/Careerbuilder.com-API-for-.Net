using System.Collections.Generic;
using com.careerbuilder.api.models.responses;
using System;

namespace com.careerbuilder.api.models {
    [Serializable]
    public class BlankApplication : Application {
        public string ApplicationSubmitServiceURL { get; set; }
        public string ApplyURL { get; set; }
        public ApplicationRequirements Requirements { get; set; }
        public string JobTitle { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalRequiredQuestions { get; set; }
    }
}