namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhiftClassToDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_datesheet", "tbl_courseId", "dbo.tbl_course");
            DropForeignKey("dbo.tbl_datesheet", "tbl_semesterId", "dbo.tbl_semester");
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_courseId" });
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_semesterId" });
            AddColumn("dbo.tbl_datesheet", "tbl_subjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_datesheet", "tbl_subjectId");
            AddForeignKey("dbo.tbl_datesheet", "tbl_subjectId", "dbo.tbl_subject", "id", cascadeDelete: true);
            DropColumn("dbo.tbl_datesheet", "tbl_courseId");
            DropColumn("dbo.tbl_datesheet", "tbl_semesterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_datesheet", "tbl_semesterId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_datesheet", "tbl_courseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbl_datesheet", "tbl_subjectId", "dbo.tbl_subject");
            DropIndex("dbo.tbl_datesheet", new[] { "tbl_subjectId" });
            DropColumn("dbo.tbl_datesheet", "tbl_subjectId");
            CreateIndex("dbo.tbl_datesheet", "tbl_semesterId");
            CreateIndex("dbo.tbl_datesheet", "tbl_courseId");
            AddForeignKey("dbo.tbl_datesheet", "tbl_semesterId", "dbo.tbl_semester", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_datesheet", "tbl_courseId", "dbo.tbl_course", "id", cascadeDelete: true);
        }
    }
}
