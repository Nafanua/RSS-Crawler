﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace RSS_Crawler.XML_Classes
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ItemEnclosure
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
        
        [XmlAttribute("length")]
        public string Length { get; set; }
        
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
