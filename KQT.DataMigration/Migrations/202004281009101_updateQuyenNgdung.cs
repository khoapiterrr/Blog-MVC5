namespace KQT.DataMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateQuyenNgdung : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucNang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenChucNang = c.String(maxLength: 50),
                        MoTa = c.String(maxLength: 500),
                        TenForm = c.String(maxLength: 100),
                        Module = c.String(maxLength: 50),
                        OrderNumber = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhanQuyen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChucNangId = c.Int(),
                        VaiTroId = c.Int(),
                        Xem = c.Boolean(),
                        Them = c.Boolean(),
                        Sua = c.Boolean(),
                        Xoa = c.Boolean(),
                        BaoCao = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucNang", t => t.ChucNangId)
                .ForeignKey("dbo.VaiTro", t => t.VaiTroId)
                .Index(t => t.ChucNangId)
                .Index(t => t.VaiTroId);
            
            CreateTable(
                "dbo.VaiTro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenVaiTro = c.String(maxLength: 150),
                        MoTa = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 50),
                        Avatar = c.String(maxLength: 50),
                        HoTen = c.String(maxLength: 30),
                        DienThoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 250),
                        NgayTao = c.DateTime(),
                        VaiTroId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VaiTro", t => t.VaiTroId)
                .Index(t => t.VaiTroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhanQuyen", "VaiTroId", "dbo.VaiTro");
            DropForeignKey("dbo.NguoiDung", "VaiTroId", "dbo.VaiTro");
            DropForeignKey("dbo.PhanQuyen", "ChucNangId", "dbo.ChucNang");
            DropIndex("dbo.NguoiDung", new[] { "VaiTroId" });
            DropIndex("dbo.PhanQuyen", new[] { "VaiTroId" });
            DropIndex("dbo.PhanQuyen", new[] { "ChucNangId" });
            DropTable("dbo.NguoiDung");
            DropTable("dbo.VaiTro");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.ChucNang");
        }
    }
}
