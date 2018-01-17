using RSS_Crawler.Interfases;
using System.Collections.Generic;
using System.Xml;

namespace RSS_Crawler
{
    public class Crawler : ICrawler
    {
        private IData_Acces DA;
        private Item[] articles;
        private List<string> Titles;
        private bool coincidenceOfTitles;


        public Crawler()
        {
            Titles = new List<string>();
            DA = new Data_Acces();
            coincidenceOfTitles = false;
        }

        public void DataExtraction(string url)
        {
            //Load All titles from Database
            Titles = DA.LoadData();

            //load RSS in Xmldoc
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            articles = new Item[root.SelectNodes("channel/item").Count];
            nodeList = root.ChildNodes;

            int counter = 0;

            //Searching of news in list of articles
            foreach (XmlNode chanel in nodeList)
            {
                foreach (XmlNode chanel_item in chanel)
                {
                    if (chanel_item.Name == "item")
                    {
                        XmlNodeList itemsList = chanel_item.ChildNodes;

                        //Creating an instance of a news class and adding in list
                        articles[counter] = new Item();

                        //Filling class fields
                        foreach (XmlNode item in itemsList)
                        {
                            if (item.Name == "title")
                            {
                                articles[counter].title = item.InnerText;
                            }
                            else if (item.Name == "link")
                            {
                                articles[counter].link = item.InnerText;
                            }
                            else if (item.Name == "description")
                            {
                                articles[counter].description = item.InnerText;
                            }
                            else if (item.Name == "pubDate")
                            {
                                articles[counter].pubDate = item.InnerText;
                            }
                            else if (item.Name == "fulltext")
                            {
                                articles[counter].fulltext = item.InnerText;
                            }
                        }

                        //Chek for repeating news
                        foreach (var title in Titles)
                        {
                            if (title.Equals(articles[counter].title))
                            {
                                coincidenceOfTitles = true;
                                break;
                            }
                            else
                            {
                                coincidenceOfTitles = false;
                            }
                        }

                        //Add new item in Database if it not exist in database
                        if (!coincidenceOfTitles)
                        {
                            DA.SaveData(articles[counter].title, articles[counter].link, articles[counter].description, articles[counter].pubDate, articles[counter].fulltext);
                        }                        

                        counter++;
                    }
                }
            }
        }
    }
}
