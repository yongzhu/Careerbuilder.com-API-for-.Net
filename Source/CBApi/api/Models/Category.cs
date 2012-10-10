using System.Collections.Generic;

namespace com.careerbuilder.api.models
{
    public class Category
    {
        public string Code { get; set; }
        public List<Name> Names { get; set; }
    }

    public class Name
    {
        public string Language { get; set; }
        public string Value { get; set; }
    }
}