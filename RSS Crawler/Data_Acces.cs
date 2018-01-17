using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Crawler
{
    class Data_Acces
    {
        private SqlConnection conn;

        public Data_Acces()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-77RDGQG\MYSQL;Initial Catalog=News;Integrated Security=True");
        }

        public void SaveData(string title, string link, string description, string pubDate, string fulltext)
        {
            conn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Items (Title, Link, Description, PubDate, FullText) " +
                                     "Values (@title, @link, @description, @pubDate, @fulltext)", conn);

            command.Parameters.Add(new SqlParameter("title", title));
            command.Parameters.Add(new SqlParameter("link", link));
            command.Parameters.Add(new SqlParameter("description", description));
            command.Parameters.Add(new SqlParameter("pubDate", pubDate));
            command.Parameters.Add(new SqlParameter("fulltext", fulltext));

            command.ExecuteNonQuery();

            conn.Close();
        }
    }
}
