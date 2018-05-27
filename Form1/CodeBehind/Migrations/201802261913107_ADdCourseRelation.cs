namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADdCourseRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_course", "semester_id", c => c.Int());
            CreateIndex("dbo.tbl_course", "semester_id");
            AddForeignKey("dbo.tbl_course", "semester_id", "dbo.tbl_semester", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_course", "semester_id", "dbo.tbl_semester");
            DropIndex("dbo.tbl_course", new[] { "semester_id" });
            DropColumn("dbo.tbl_course", "semester_id");
        }
    }
}
