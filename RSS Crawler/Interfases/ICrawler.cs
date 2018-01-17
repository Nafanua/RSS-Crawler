using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Crawler.Interfases
{
    interface ICrawler
    {
        void DataExtraction(string url);
    }
}
