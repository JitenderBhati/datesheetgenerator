namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateSheetComplete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_block", "tbl_datesheetId", "dbo.tbl_datesheet");
            DropIndex("dbo.tbl_block", new[] { "tbl_datesheetId" });
            AddColumn("dbo.tbl_datesheet", "shift", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.tbl_datesheet", "tbl_blockId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_datesheet", "tbl_blockId");
            AddForeignKey("dbo.tbl_datesheet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_block", "tbl_datesheetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_block", "tbl_datesheetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_datesheet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_blockId" });
            DropColumn("dbo.tbl_datesheet", "tbl_blockId");
            DropColumn("dbo.tbl_datesheet", "date");
            DropColumn("dbo.tbl_datesheet", "shift");
            CreateIndex("dbo.tbl_block", "tbl_datesheetId");
            AddForeignKey("dbo.tbl_block", "tbl_datesheetId", "dbo.tbl_datesheet", "id", cascadeDelete: true);
        }
    }
}
