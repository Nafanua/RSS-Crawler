using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("channel")]
        public RssChannel Channel { get; set; }
    }
}
