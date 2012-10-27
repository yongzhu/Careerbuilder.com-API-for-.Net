using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api {
    [Serializable]
    public class APITimeoutException : APIException {
        public APITimeoutException(string message)
            : base(message) {
        }
    }
}
