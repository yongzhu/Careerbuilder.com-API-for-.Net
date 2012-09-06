using System;
using System.Collections.Generic;

namespace com.careerbuilder.api.models.responses
{
    public class ResponseJobReport
    {
        public DateTime TimeResponseSent { get; set; }
        public float TimeElapsed { get; set; }
        public string JobDID { get; set; }
        public int TotalApps { get; set; }
        public Bucket Buckets { get; set; }
    }
}
