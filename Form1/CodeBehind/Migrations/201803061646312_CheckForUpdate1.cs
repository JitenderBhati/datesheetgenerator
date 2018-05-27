namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckForUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_block", "datasheet_id", "dbo.tbl_datesheet");
            DropIndex("dbo.tbl_block", new[] { "datasheet_id" });
            RenameColumn(table: "dbo.tbl_block", name: "datasheet_id", newName: "tbl_datesheetId");
            AlterColumn("dbo.tbl_block", "tbl_datesheetId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_block", "tbl_datesheetId");
            AddForeignKey("dbo.tbl_block", "tbl_datesheetId", "dbo.tbl_datesheet", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_block", "tbl_datasheetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_block", "tbl_datasheetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_block", "tbl_datesheetId", "dbo.tbl_datesheet");
            DropIndex("dbo.tbl_block", new[] { "tbl_datesheetId" });
            AlterColumn("dbo.tbl_block", "tbl_datesheetId", c => c.Int());
            RenameColumn(table: "dbo.tbl_block", name: "tbl_datesheetId", newName: "datasheet_id");
            CreateIndex("dbo.tbl_block", "datasheet_id");
            AddForeignKey("dbo.tbl_block", "datasheet_id", "dbo.tbl_datesheet", "id");
        }
    }
}
