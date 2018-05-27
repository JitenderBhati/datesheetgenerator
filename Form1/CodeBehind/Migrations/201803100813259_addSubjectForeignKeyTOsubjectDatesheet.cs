namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjectForeignKeyTOsubjectDatesheet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_subjectDatesheet", "tbl_subjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_subjectID");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectID", "dbo.tbl_subject", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectID", "dbo.tbl_subject");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_subjectID" });
            DropColumn("dbo.tbl_subjectDatesheet", "tbl_subjectID");
        }
    }
}
