using System.Xml.Serialization;

namespace ITechArt.Models.ForXML
{
    [XmlRoot(ElementName = "pets")]
    public class Pets
    {
        [XmlElement(ElementName = "pet")]
        public List<Pet> Pet { get; set; }
    }
}
