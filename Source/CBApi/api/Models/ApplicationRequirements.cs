using System;

namespace com.careerbuilder.api.models {
    [Serializable]
    public class ApplicationRequirements {
        public string DegreeRequired { get; set; }
        public string TravelRequired { get; set; }
        public string ExperienceRequired { get; set; }
        public string RequirementsText { get; set; }
    }
}
