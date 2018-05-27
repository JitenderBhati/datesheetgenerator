namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBlockRefernceFromTableSubjectDatesheet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_blockId", "dbo.tbl_block");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_blockId" });
            DropColumn("dbo.tbl_subjectDatesheet", "tbl_blockId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_subjectDatesheet", "tbl_blockId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_blockId");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_blockId", "dbo.tbl_block", "id", cascadeDelete: true);
        }
    }
}
