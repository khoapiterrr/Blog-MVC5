namespace KQT.DataMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uplengthPwdCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NguoiDung", "MatKhau", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NguoiDung", "MatKhau", c => c.String(maxLength: 50));
        }
    }
}
