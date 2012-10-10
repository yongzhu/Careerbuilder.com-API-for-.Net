namespace com.careerbuilder.api.models.responses
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string QuestionType { get; set; }
        public bool IsRequired { get; set; }
        public string ExpectedResponseFormat { get; set; }
        public string QuestionText { get; set; }
    }
}