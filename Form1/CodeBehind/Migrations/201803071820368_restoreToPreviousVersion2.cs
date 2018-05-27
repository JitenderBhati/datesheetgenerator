namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoreToPreviousVersion2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectID", "dbo.tbl_subject");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_subjectID" });
            AddColumn("dbo.tbl_subjectDatesheet", "tbl_shiftId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_shiftId");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_shiftId", "dbo.tbl_shift", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_subjectDatesheet", "tbl_subjectID");
            DropColumn("dbo.tbl_subjectDatesheet", "shift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_subjectDatesheet", "shift", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_subjectDatesheet", "tbl_subjectID", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_subjectDatesheet", "tbl_shiftId", "dbo.tbl_shift");
            DropIndex("dbo.tbl_subjectDatesheet", new[] { "tbl_shiftId" });
            DropColumn("dbo.tbl_subjectDatesheet", "tbl_shiftId");
            CreateIndex("dbo.tbl_subjectDatesheet", "tbl_subjectID");
            AddForeignKey("dbo.tbl_subjectDatesheet", "tbl_subjectID", "dbo.tbl_subject", "id", cascadeDelete: true);
        }
    }
}
