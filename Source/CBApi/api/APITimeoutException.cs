using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api {
    public class APITimeoutException : APIException {
        public APITimeoutException(string message)
            : base(message) {
        }
    }
}
