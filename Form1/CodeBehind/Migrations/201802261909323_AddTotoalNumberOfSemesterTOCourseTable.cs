namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotoalNumberOfSemesterTOCourseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_course", "semester_id", "dbo.tbl_semester");
            DropIndex("dbo.tbl_course", new[] { "semester_id" });
            AddColumn("dbo.tbl_course", "total_number_of_Semester", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_course", "semester_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_course", "semester_id", c => c.Int());
            DropColumn("dbo.tbl_course", "total_number_of_Semester");
            CreateIndex("dbo.tbl_course", "semester_id");
            AddForeignKey("dbo.tbl_course", "semester_id", "dbo.tbl_semester", "id");
        }
    }
}
