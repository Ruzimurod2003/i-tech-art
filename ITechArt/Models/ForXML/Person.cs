using System.Xml.Serialization;

namespace ITechArt.Models.ForXML
{
    [XmlRoot(ElementName = "person")]
    public class Person
    {
        [XmlElement(ElementName = "pets")]
        public Pets Pets { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }
    }
}
