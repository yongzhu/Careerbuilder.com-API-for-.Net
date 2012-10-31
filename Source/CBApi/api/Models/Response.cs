using System;
namespace com.careerbuilder.api.models {
    [Serializable]
    public class Response {
        public string QuestionID { get; set; }
        public string ResponseText { get; set; }
    }
}
