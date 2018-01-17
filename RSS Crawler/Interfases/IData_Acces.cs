using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Crawler.Interfases
{
    interface IData_Acces
    {
        void SaveData(string title, string link, string description, string pubDate, string fulltext);
        List<string> LoadData();
    }
}
