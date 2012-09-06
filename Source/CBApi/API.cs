using com.careerbuilder.api;

namespace com.careerbuilder
{
    public class API
    {
        public static ICBApi GetInstance()
        {
            return new CBApi();
        }

        public static ICBApi GetInstance(string developerKey)
        {
            return new CBApi(developerKey);
        }

        public static ICBApi GetInstance(string developerKey,string cobrandCode)
        {
            return new CBApi(developerKey, cobrandCode);
        }

        public static ICBApi GetInstance(string developerKey,string cobrandCode, string siteID)
        {
            return new CBApi(developerKey,cobrandCode,siteID);
        }
    }
}
