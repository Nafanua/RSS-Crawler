using System;
using System.Data.Entity;

namespace DAL
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("Items")
        { }

        public DbSet<RssChannelItemDbo> Items { get; set; }
    }
}
