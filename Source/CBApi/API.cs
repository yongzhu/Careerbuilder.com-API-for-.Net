using com.careerbuilder.api;

namespace com.careerbuilder
{
    public class API
    {
        public static ICBApi GetInstance()
        {
            return new CbApi();
        }

        public static ICBApi GetInstance(string developerKey)
        {
            return new CbApi(developerKey);
        }

        public static ICBApi GetInstance(string developerKey, string cobrandCode)
        {
            return new CbApi(developerKey, cobrandCode);
        }

        public static ICBApi GetInstance(string developerKey, string cobrandCode, string siteID)
        {
            return new CbApi(developerKey, cobrandCode, siteID);
        }
    }
}