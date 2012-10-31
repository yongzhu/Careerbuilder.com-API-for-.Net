using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.framework.events {
    public delegate void BeforeRequestEvent(IRequestEventData data);
    public delegate void AfterRequestEvent(IRequestEventData data);
}
