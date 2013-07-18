using System;

namespace CBApi.Models
{
    [Serializable]
    class RequestSavedSearchDelete
    {
        public string DeveloperKey { get; set; }
        public string ExternalID { get; set; }
        public string ExternalUserID { get; set; }
        public String HostSite { get; set; }
    }
}
