namespace CodeBehind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRelationbtwncoursesandsemestertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_course", "tbl_semesterId", "dbo.tbl_semester");
            DropIndex("dbo.tbl_course", new[] { "tbl_semesterId" });
            DropColumn("dbo.tbl_course", "tbl_semesterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_course", "tbl_semesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_course", "tbl_semesterId");
            AddForeignKey("dbo.tbl_course", "tbl_semesterId", "dbo.tbl_semester", "id", cascadeDelete: true);
        }
    }
}
