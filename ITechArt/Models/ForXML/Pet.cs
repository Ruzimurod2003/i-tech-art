using System.Xml.Serialization;

namespace ITechArt.Models.ForXML
{
    [XmlRoot(ElementName = "pet")]
    public class Pet
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
