namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesinBlockSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_subjectDatesheetid" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            AlterColumn("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", c => c.Int());
            AlterColumn("dbo.tbl_BlockSet", "tbl_blockId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_BlockSet", "tbl_subjectDatesheetid");
            CreateIndex("dbo.tbl_BlockSet", "tbl_blockId");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet");
            DropForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_blockId" });
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_subjectDatesheetid" });
            AlterColumn("dbo.tbl_BlockSet", "tbl_blockId", c => c.Int());
            AlterColumn("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_BlockSet", "tbl_blockId");
            CreateIndex("dbo.tbl_BlockSet", "tbl_subjectDatesheetid");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_BlockSet", "tbl_blockId", "dbo.tbl_block", "id");
        }
    }
}
