using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RssChannel
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("image")]
        public RssChannelImage Image { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("category")]
        public string[] CategoryField { get; set; }

        [XmlElement("copyright")]
        public string Copyright { get; set; }

        [XmlElement("managingEditor")]
        public string ManagingEditor { get; set; }

        [XmlElement("item")]
        public RssChannelItem[] Item { get; set; }
    }
}
