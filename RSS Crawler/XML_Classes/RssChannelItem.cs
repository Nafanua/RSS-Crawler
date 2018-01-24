using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RssChannelItem
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("fulltext")]
        public string Fulltext { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        [XmlElement("guid")]
        public string Guid { get; set; }

        [XmlElement("category")]
        public ItemCategory Category { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("source")]
        public ItemSource Source { get; set; }

        [XmlElement("tags", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Tags { get; set; }

        [XmlElement("enclosure")]
        public ItemEnclosure Enclosure { get; set; }
    }
}
