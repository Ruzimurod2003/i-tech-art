using ITechArt.Models.ForXML;
using System.Xml.Linq;

namespace ITechArt.Functions
{
    public interface IFileXML
    {
        void WriteXML(People value);
    }
    public class FileXML: IFileXML
    {
        private readonly IConfiguration config;

        public FileXML(IConfiguration _config)
        {
            config = _config;
        }
        public void WriteXML(People value)
        {
            string filePath = config["Location:FileXML"];
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(People));
            FileStream file = File.Create(filePath);
            writer.Serialize(file, value);
            file.Close();
        }
    }
}
