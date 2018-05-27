namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectTableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_subject",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        tbl_courseId = c.Int(nullable: false),
                        tbl_semesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_course", t => t.tbl_courseId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_semester", t => t.tbl_semesterId, cascadeDelete: true)
                .Index(t => t.tbl_courseId)
                .Index(t => t.tbl_semesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_subject", "tbl_semesterId", "dbo.tbl_semester");
            DropForeignKey("dbo.tbl_subject", "tbl_courseId", "dbo.tbl_course");
            DropIndex("dbo.tbl_subject", new[] { "tbl_semesterId" });
            DropIndex("dbo.tbl_subject", new[] { "tbl_courseId" });
            DropTable("dbo.tbl_subject");
        }
    }
}
