using System.Collections.Generic;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.models
{
    public class BlankApplication : Application
    {
        public string ApplicationSubmitServiceURL { get; set; }
        public string ApplyURL { get; set; }
        public string JobDID { get; set; }
        public string JobTitle { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalRequiredQuestions { get; set; }
        public List<Question> Questions { get; set; }
    }
}