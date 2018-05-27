namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesIntbl_courseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_course", "tbl_departmentId", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_course", "tbl_semesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_course", "tbl_departmentId");
            CreateIndex("dbo.tbl_course", "tbl_semesterId");
            AddForeignKey("dbo.tbl_course", "tbl_departmentId", "dbo.tbl_department", "id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_course", "tbl_semesterId", "dbo.tbl_semester", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_course", "tbl_semesterId", "dbo.tbl_semester");
            DropForeignKey("dbo.tbl_course", "tbl_departmentId", "dbo.tbl_department");
            DropIndex("dbo.tbl_course", new[] { "tbl_semesterId" });
            DropIndex("dbo.tbl_course", new[] { "tbl_departmentId" });
            DropColumn("dbo.tbl_course", "tbl_semesterId");
            DropColumn("dbo.tbl_course", "tbl_departmentId");
        }
    }
}
