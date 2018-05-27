namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFinalDatesheetToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_finalDatesheet",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    tbl_typeId = c.Int(nullable: false),
                    tbl_courseId = c.Int(nullable: false),
                    tbl_semesterId = c.Int(nullable: false),
                    tbl_subjectDatesheet = c.Int(nullable: false),
                    subjectDatesheet_id = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_course", t => t.tbl_courseId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_semester", t => t.tbl_semesterId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_subjectDatesheet", t => t.subjectDatesheet_id, cascadeDelete:true)
                .ForeignKey("dbo.tbl_type", t => t.tbl_typeId, cascadeDelete: false)
                .Index(t => t.tbl_typeId)
                .Index(t => t.tbl_courseId)
                .Index(t => t.tbl_semesterId)
                .Index(t => t.subjectDatesheet_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_finalDatesheet", "tbl_typeId", "dbo.tbl_type");
            DropForeignKey("dbo.tbl_finalDatesheet", "subjectDatesheet_id", "dbo.tbl_subjectDatesheet");
            DropForeignKey("dbo.tbl_finalDatesheet", "tbl_semesterId", "dbo.tbl_semester");
            DropForeignKey("dbo.tbl_finalDatesheet", "tbl_courseId", "dbo.tbl_course");
            DropIndex("dbo.tbl_finalDatesheet", new[] { "subjectDatesheet_id" });
            DropIndex("dbo.tbl_finalDatesheet", new[] { "tbl_semesterId" });
            DropIndex("dbo.tbl_finalDatesheet", new[] { "tbl_courseId" });
            DropIndex("dbo.tbl_finalDatesheet", new[] { "tbl_typeId" });
            DropTable("dbo.tbl_finalDatesheet");
        }
    }
}
