using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api {
    public class APIException : Exception {
        public APIException(string message) : base(message){
        }
    }
}
