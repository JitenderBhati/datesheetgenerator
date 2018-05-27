namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateSheetIdToBlockSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            AddColumn("dbo.tbl_BlockSet", "tbl_datesheetId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_BlockSet", "tbl_blockId", c => c.Int());
            CreateIndex("dbo.tbl_BlockSet", "tbl_blockId");
            CreateIndex("dbo.tbl_BlockSet", "tbl_datesheetId");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_datesheetId", "dbo.tbl_datesheet", "id");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_datesheetId", "dbo.tbl_datesheet");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_datesheetId" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            AlterColumn("dbo.tbl_BlockSet", "tbl_blockId", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_BlockSet", "tbl_datesheetId");
            CreateIndex("dbo.tbl_BlockSet", "tbl_blockId");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
        }
    }
}
