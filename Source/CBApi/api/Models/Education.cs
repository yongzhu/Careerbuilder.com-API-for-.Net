using System;
using System.Collections.Generic;

namespace com.careerbuilder.api.models {
    [Serializable]
    public class Education {
        public string Code { get; set; }
        public List<Name> Names { get; set; }
    }
}