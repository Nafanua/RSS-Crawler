namespace DAL
{
    public partial class RssChannelItemDbo
    {
        public int Id { get; set; }

        public int HashId { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Fulltext { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public string PubDate { get; set; }

        public string Guid { get; set; }

        public string CategoryUrl { get; set; }

        public string Comments { get; set; }

        public string SourceUrl { get; set; }

        public string Tags { get; set; }

        public string EnclosureUrl { get; set; }
    }
}
