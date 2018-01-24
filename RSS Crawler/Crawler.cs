using RSS_Crawler.Interfases;
using System.IO;
using System.Xml.Serialization;
using System.Net.Http;
using RSS_Crawler.XML_Classes;
using DataContract;
using System.Collections.Generic;
using DAL;
using NLog;
using System;

namespace RSS_Crawler
{
    public class Crawler : ICrawler
    {
        private string xmlString;
        private StringReader reader;
        private XmlSerializer sr;
        private Rss ExtractedData;
        private HttpClient client;
        private IData_Contract dataContract;
        private Logger logger;

        public Crawler()
        {
            sr = new XmlSerializer(typeof(Rss));
            client = new HttpClient();
            dataContract = new Data_Contract();
            logger = LogManager.GetCurrentClassLogger();
        }

        public void DataExtraction(string url)
        {
            logger.Trace("Start deserializing XML");

            xmlString = this.GetXml(url);

            reader = new StringReader(xmlString);
            
            ExtractedData = (sr.Deserialize(reader) as Rss);

            try
            {
                dataContract.MapperStart(ExtractedData);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            
        }

        private string GetXml(string url)
        {            
            return client.GetStringAsync(url).Result;
        }
    }
}
