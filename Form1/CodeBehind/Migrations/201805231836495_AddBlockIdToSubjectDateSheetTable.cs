namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlockIdToSubjectDateSheetTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_subjectDatesheet", "tbl_blockId", c => c.Int(nullable: true));
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_blockId");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_blockId" });
            DropColumn("dbo.tbl_subjectDatesheet", "tbl_blockId");
        }
    }
}
