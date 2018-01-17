using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Crawler
{
    class Item
    {
        public string title;
        public string link;
        public string description;
        public string pubDate;
        public string fulltext;

        public Item()
        {
            title = "";
            link = "";
            description = "";
            pubDate = "";
            fulltext = "";
        }
    }
}
