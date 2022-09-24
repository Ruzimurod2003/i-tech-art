using System.Xml.Serialization;
using System;

namespace ITechArt.Models.ForXML
{
    [XmlRoot(ElementName = "people")]
    public class People
    {
        [XmlElement(ElementName = "person")]
        public List<Person> Person { get; set; }
    }
}
