namespace KQT.DataMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactEntities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 30),
                        Message = c.String(),
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
            DropTable("dbo.ContactEntities");
        }
    }
}
