using System.Xml.Serialization;

namespace com.careerbuilder.api.models
{
    public class Bucket
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        //public Item item { get; set; }
    }
}