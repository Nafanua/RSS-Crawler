using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSS_Crawler
{
    public class Crawler
    {
        Data_Acces DA;
        private Item[] articles;
        private bool fail;

        public Crawler()
        {
            DA = new Data_Acces();
            fail = false;
        }

        public void DataExtraction(string url)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            articles = new Item[root.SelectNodes("channel/item").Count];
            nodeList = root.ChildNodes;

            int counter = 0;

            foreach (XmlNode chanel in nodeList)
            {
                foreach (XmlNode chanel_item in chanel)
                {
                    if (chanel_item.Name == "item")
                    {
                        XmlNodeList itemsList = chanel_item.ChildNodes;
                        articles[counter] = new Item();

                        foreach (XmlNode item in itemsList)
                        {
                            if (item.Name == "title")
                            {
                                articles[counter].title = item.InnerText;
                            }
                            if (item.Name == "link")
                            {
                                articles[counter].link = item.InnerText;
                            }
                            if (item.Name == "description")
                            {
                                articles[counter].description = item.InnerText;
                            }
                            if (item.Name == "pubDate")
                            {
                                articles[counter].pubDate = item.InnerText;
                            }
                            if (item.Name == "fulltext")
                            {
                                articles[counter].fulltext = item.InnerText;
                            }
                        }

                        DA.SaveData(articles[counter].title, articles[counter].link, articles[counter].description, articles[counter].pubDate, articles[counter].fulltext);

                        counter++;
                    }
                }
            }

        }
    }
}
