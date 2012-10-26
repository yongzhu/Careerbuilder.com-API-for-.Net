using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api {
    public class APIException : Exception {

        public List<string> APIErrors { get; set; }
        public APIException(string message) : base(message){
            APIErrors.Add(message);
        }

        public APIException(string message,List<string> errors) : base(message) {
            APIErrors = errors;
        }
    }
}
