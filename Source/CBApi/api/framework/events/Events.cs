using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.framework.events {
    public delegate void BeforeRequestEvent(IRestClient client, IRestRequest request);
    public delegate void AfterRequestEvent(IRestClient client, IRestRequest request, IRestResponse response);
}
