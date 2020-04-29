namespace KQT.DataMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        NewTitle = c.String(nullable: false, maxLength: 255),
                        NewTitleSale = c.String(),
                        NewContentHead = c.String(storeType: "ntext"),
                        NewContentBody = c.String(storeType: "ntext"),
                        NewContentFooter = c.String(storeType: "ntext"),
                        ImageHead = c.String(maxLength: 4000),
                        ImageBody = c.String(maxLength: 4000),
                        ImageFooter = c.String(maxLength: 4000),
                        ViewCount = c.Int(nullable: false),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
        }
    }
}
