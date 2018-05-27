namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblocktableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_block",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tbl_datasheetId = c.Int(nullable: false),
                        name = c.String(),
                        datasheet_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_datesheet", t => t.datasheet_id)
                .Index(t => t.datasheet_id);
            
            DropTable("dbo.tbl_holiday");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_holiday",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.tbl_block", "datasheet_id", "dbo.tbl_datesheet");
            DropIndex("dbo.tbl_block", new[] { "datasheet_id" });
            DropTable("dbo.tbl_block");
        }
    }
}
