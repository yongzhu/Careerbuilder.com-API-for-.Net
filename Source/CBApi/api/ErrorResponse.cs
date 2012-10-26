using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api {
    public class ErrorResponse {
        public Errors Errors { get; set; }
        public string TimeResponseSent { get; set; }
        public string TimeElapsed { get; set; }
    }

    public class Errors {
        public string Error { get; set; }
    }
}
