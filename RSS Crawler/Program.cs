using RSS_Crawler.Interfases;
using System;

namespace RSS_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Fail = false;

            Console.Write(" Enter URL of RSS: ");
            string url = Console.ReadLine();
            Console.WriteLine();

            ICrawler cr = new Crawler();

            try
            {
                cr.DataExtraction(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Failed");
                Console.WriteLine(ex.Message);
                Fail = true;
            }

            if (!Fail)
            {
                Console.WriteLine(" Sucsess");
            }

            Console.ReadKey();
        }
    }
}
