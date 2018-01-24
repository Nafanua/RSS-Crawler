namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RssChannelItemDboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Description = c.String(),
                        Fulltext = c.String(),
                        Author = c.String(),
                        Image = c.String(),
                        PubDate = c.String(),
                        Guid = c.String(),
                        CategoryUrl = c.String(),
                        Comments = c.String(),
                        SourceUrl = c.String(),
                        Tags = c.String(),
                        EnclosureUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RssChannelItemDboes");
        }
    }
}
