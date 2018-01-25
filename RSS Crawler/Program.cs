using NLog;
using RSS_Crawler.Interfases;
using System;

namespace RSS_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            bool Fail = false;
            
            string url = string.Empty;

            if (args.Length > 0)
            {
                url =  args[0];
            }
            else
            {
                Console.Write("Enter URL of RSS: ");
                url = Console.ReadLine();
                Console.WriteLine();
            }
            logger.Trace("Target URL: " + url);
            logger.Trace("Crawler started");

            ICrawler cr = new Crawler();           

            try
            {
                cr.DataExtraction(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                Fail = true;
            }

            if (!Fail)
            {
                logger.Trace("Succes");
            }
        }
    }
}
