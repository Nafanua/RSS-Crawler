using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ItemCategory
    {
        [XmlAttribute("domain")]
        public string Domain { get; set; }

        [XmlText()]
        public string Value { get; set; }
    }
}
