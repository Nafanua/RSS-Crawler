using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RssChannelImage
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("width")]
        public byte Width { get; set; }

        [XmlElement("height")]
        public byte Height { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
    }
}
