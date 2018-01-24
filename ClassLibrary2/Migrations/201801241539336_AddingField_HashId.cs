namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingField_HashId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RssChannelItemDboes", "HashId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RssChannelItemDboes", "HashId");
        }
    }
}
