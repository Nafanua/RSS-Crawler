namespace RSS_Crawler
{
    class Item
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
        public string fulltext { get; set; }

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
