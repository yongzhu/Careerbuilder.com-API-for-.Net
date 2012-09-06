using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
