namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_BlockSet", "subject_id", "dbo.tbl_subjectDatesheet");
            DropIndex("dbo.tbl_BlockSet", new[] { "subject_id" });
            RenameColumn(table: "dbo.tbl_BlockSet", name: "subject_id", newName: "tbl_subjectDatesheetid");
            AlterColumn("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_BlockSet", "tbl_subjectDatesheetid");
            AddForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_BlockSet", "tbl_subjectDateshhetid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_BlockSet", "tbl_subjectDateshhetid", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", "dbo.tbl_subjectDatesheet");
            DropIndex("dbo.tbl_BlockSet", new[] { "tbl_subjectDatesheetid" });
            AlterColumn("dbo.tbl_BlockSet", "tbl_subjectDatesheetid", c => c.Int());
            RenameColumn(table: "dbo.tbl_BlockSet", name: "tbl_subjectDatesheetid", newName: "subject_id");
            CreateIndex("dbo.tbl_BlockSet", "subject_id");
            AddForeignKey("dbo.tbl_BlockSet", "subject_id", "dbo.tbl_subjectDatesheet", "id");
        }
    }
}
