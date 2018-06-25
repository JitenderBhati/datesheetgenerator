namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableStudentCapacityTodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_studentCapacity",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        capacity = c.Int(nullable: false),
                        tbl_semesterId = c.Int(nullable: false),
                        tbl_courseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tbl_course", t => t.tbl_courseId, cascadeDelete: false)
                .ForeignKey("dbo.tbl_semester", t => t.tbl_semesterId, cascadeDelete: false)
                .Index(t => t.tbl_semesterId)
                .Index(t => t.tbl_courseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_studentCapacity", "tbl_semesterId", "dbo.tbl_semester");
            DropForeignKey("dbo.tbl_studentCapacity", "tbl_courseId", "dbo.tbl_course");
            DropIndex("dbo.tbl_studentCapacity", new[] { "tbl_courseId" });
            DropIndex("dbo.tbl_studentCapacity", new[] { "tbl_semesterId" });
            DropTable("dbo.tbl_studentCapacity");
        }
    }
}
